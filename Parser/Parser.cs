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

            CheckType(TokenType.Dot, true);
            return new Program(identifier, identifiersList, declarations);
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
                CheckType(TokenType.Identifier, false);
                identifiers.Add(new Identifier(Next().Value));
                CheckComma(finalType);
            }

            return new IdentifierList(identifiers);
        }

        public NonTerminal Declarations()
        {
            var declarations = new List<Declaration>();
            while (CheckWord("var", false))
            {
                var declaration = Declaration();
                declarations.Add(declaration);
            }

            return new Declarations(declarations);
        }

        public Declaration Declaration()
        {
            var identifierList = IdentifierList(TokenType.Colon);
            CheckWord(":", true);

            Type type = null;
            if (CheckWord("array", false))
            {
                type = GetArray();
            }
            else
            {
                CheckType(TokenType.Type, false);
                var token = Next();
                type = new Type(token.Value);
            }

            CheckType(TokenType.Semicolon, true);
            return new Declaration(identifierList, type);
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

        private bool CheckComma(TokenType finalType)
        {
            var token = Peek();
            var type = token.TokenType;

            if (type != TokenType.Comma && type != finalType)
                throw new InvalidDataException("missing comma");

            if (type != TokenType.Comma) return true;

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