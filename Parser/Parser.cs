using System.Collections.Generic;
using System.IO;
using HelloWorld.Language;
using HelloWorld.Lexer.Token;

namespace HelloWorld.Parser
{
    public class Parser : INotation
    {
        private List<Token> _tokens;
        private int _index;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
        }


        public NonTerminal Parse()
        {
            if (IsEnd()) throw new InvalidDataException("empty token list");
            return Program();
        }

        public NonTerminal Program()
        {
            CheckWord("program", true);
            var identifier = Identifier();

            CheckType(TokenType.LeftParenthesis, true);
            var identifiersList = IdentifierList(TokenType.RightParenthesis);
            CheckType(TokenType.RightParenthesis, true);

            CheckType(TokenType.Semicolon, true);

            var declarations = Declarations();
            var subprogramDeclarations = SubprogramDeclarations();
            var compoundStatements = CompoundStatement();

            CheckType(TokenType.Dot, true);
            return new Program(identifier, identifiersList, declarations, subprogramDeclarations, compoundStatements);
        }

        public Identifier Identifier()
        {
            CheckType(TokenType.Identifier, false);

            return new Identifier(Next().Value);
        }

        public NonTerminal IdentifierList(TokenType finalType)
        {
            var identifiers = new List<Identifier>();

            while (Peek().TokenType != finalType)
            {
                identifiers.Add(Identifier());
                CheckSymbol(finalType, TokenType.Comma);
            }

            return new IdentifierList(identifiers);
        }

        public NonTerminal Declarations()
        {
            var declarations = new List<NonTerminal>();
            while (CheckWord("var", false))
            {
                var declaration = Declaration();
                CheckType(TokenType.Semicolon, true);
                declarations.Add(declaration);
            }

            return new Declarations(declarations);
        }

        public NonTerminal Declaration()
        {
            var identifierList = IdentifierList(TokenType.Colon);
            CheckWord(":", true);
            var type = Type();

            return new Declaration(identifierList, type);
        }

        public Type Type()
        {
            if (CheckWord("array", false))
            {
                return GetArray();
            }

            CheckType(TokenType.Type, false);
            var token = Next();
            return new Type(token.Value);
        }

        public NonTerminal SubprogramDeclarations()
        {
            var subprograms = new List<NonTerminal>();

            while (true)
            {
                var first = CheckWord("procedure", false);
                var second = CheckWord("function", false);
                if (!first && !second) break;

                var subprogramType = first ? SubprogramType.Procedure : SubprogramType.Function;

                var subprogram = Subprogram(subprogramType);
                subprograms.Add(subprogram);
            }

            CheckType(TokenType.Semicolon, true);
            return new SubprogramDeclarations(subprograms);
        }

        public NonTerminal Subprogram(SubprogramType type)
        {
            var subprogramHead = SubprogramHead(type);
            var declarations = Declarations();
            var compoundStatements = CompoundStatement();
            return new Subprogram(subprogramHead, declarations, compoundStatements);
        }

        public NonTerminal SubprogramHead(SubprogramType subprogramType)
        {
            var identifier = Identifier();
            var parameters = new List<NonTerminal>();

            CheckType(TokenType.LeftParenthesis, true);

            while (Peek().TokenType != TokenType.RightParenthesis)
            {
                var declaration = Declaration();
                parameters.Add(declaration);
                CheckSymbol(TokenType.RightParenthesis, TokenType.Semicolon);
            }

            Eat();

            Type returnType = null;
            if (subprogramType == SubprogramType.Function)
            {
                CheckType(TokenType.Colon, true);
                returnType = Type();
            }

            CheckType(TokenType.Semicolon, true);

            return new SubprogramHead(subprogramType, identifier, parameters, returnType);
        }

        public NonTerminal CompoundStatement()
        {
            var statements = new List<NonTerminal>();

            CheckWord("begin", true);
            while (!CheckWord("end", false))
            {
                var statement = Statement();
                statements.Add(statement);
                CheckType(TokenType.Semicolon, true);
            }

            return new CompoundStatement(statements);
        }

        public NonTerminal Statement()
        {
            var token = Next();

            switch (token.Value)
            {
                case "begin":
                {
                    var statements = new List<NonTerminal>();
                    while (!CheckWord("end", false))
                    {
                        var statement = Statement();
                        statements.Add(statement);
                        CheckType(TokenType.Semicolon, true);
                    }

                    return new CompoundStatement(statements);
                }

                case "if":
                {
                    break;
                }

                case "while":
                {
                    break;
                }

                default:
                {
                    if (token.TokenType != TokenType.Identifier) throw new InvalidDataException("illegal keyword");
                    var identifier = new Identifier(token.Value);
                    CheckType(TokenType.AssignOp, true);
                    return new AssignStatement(StatementType.Assign, identifier, Expression());
                }
            }

            return null;
        }

        public NonTerminal Expression()
        {
            var first = SimpleExpression();
            var notExistsRel = Peek().TokenType != TokenType.RelOp;
            var relOp = notExistsRel ? RelOperation.None :
                (Peek().Value == "<") ? RelOperation.Less : RelOperation.More;
            if (!notExistsRel) Eat();
            var second = (notExistsRel) ? null : SimpleExpression();

            return new Expression(first, second, relOp);
        }

        public NonTerminal SimpleExpression()
        {
            var simples = new List<Simple>();
            while (true)
            {
                var term = Term();
                var notExistsAdd = Peek().TokenType != TokenType.AddOp;
                var addOp = notExistsAdd ? AddOpertaion.None :
                    (Peek().Value == "+") ? AddOpertaion.Add : AddOpertaion.Sub;
                simples.Add(new Simple(term, addOp));
                if (notExistsAdd) break;
                Eat();
            }

            return new SimpleExpression(simples);
        }

        public NonTerminal Term()
        {
            var simpleTerms = new List<SimpleTerm>();
            while (true)
            {
                var factor = Factor();
                var notExistsMul = Peek().TokenType != TokenType.MulOp;
                var mulOp = notExistsMul ? MulOperation.None :
                    (Peek().Value == "*") ? MulOperation.Mul : MulOperation.Div;
                simpleTerms.Add(new SimpleTerm(factor, mulOp));
                if (notExistsMul) break;
                Eat();
            }

            return new Term(simpleTerms);
        }

        public NonTerminal Factor()
        {
            var token = Next();

            switch (token.TokenType)
            {
                case TokenType.Identifier:
                {
                    return new Factor(FactorType.Id, new Identifier(token.Value));
                }

                case TokenType.Num:
                {
                    return new Factor(FactorType.Num, token.Value);
                }

                case TokenType.LeftParenthesis:
                {
                    var expression = Expression();
                    CheckType(TokenType.RightParenthesis, true);
                    return new Factor(FactorType.Exp, expression);
                }

                default:
                {
                    // not
                    break;
                }
            }

            return null;
        }

        private Token Next()
        {
            return _tokens[_index++];
        }

        private Token Peek()
        {
            return _tokens[_index];
        }

        private void Eat()
        {
            _index++;
        }

        private bool IsEnd()
        {
            return _tokens.Count == 0;
        }

        private bool CheckWord(string word, bool needException)
        {
            var token = Peek();
            if (!token.Value.Equals(word))
            {
                if (needException) throw new InvalidDataException("missing " + word);
                return false;
            }

            Eat();
            return true;
        }

        private bool CheckType(TokenType type, bool needEat)
        {
            var token = Peek();
            if (token.TokenType != type)
                throw new InvalidDataException("doesnt match type " + type);

            if (needEat) Eat();
            return true;
        }

        private bool CheckSymbol(TokenType finalType, TokenType symbol)
        {
            var token = Peek();
            var type = token.TokenType;

            if (type != symbol && type != finalType)
                throw new InvalidDataException("missing " + symbol);

            if (type != symbol) return true;

            Eat();
            if (Peek().TokenType == finalType)
                throw new InvalidDataException("missing identifier");

            return true;
        }

        private ArrayType GetArray()
        {
            CheckType(TokenType.LeftBracket, true);
            CheckType(TokenType.Num, false);
            int lower = System.Convert.ToInt32(Next().Value);
            CheckType(TokenType.Dots, true);
            CheckType(TokenType.Num, false);
            int upper = System.Convert.ToInt32(Next().Value);
            CheckType(TokenType.RightBracket, true);

            CheckWord("of", true);
            CheckType(TokenType.Type, false);
            var token = Next();
            return new ArrayType(token.Value, lower, upper);
        }
    }
}