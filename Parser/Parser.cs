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

        private bool CheckType(TokenType type)
        {
            var token = Peek();
            if (token.TokenType != type)
                throw new InvalidDataException("doesnt match type " + type);

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

        public NonTerminal Parse()
        {
            if (IsEnd()) throw new InvalidDataException("empty token list");
            return Program();
        }

        public NonTerminal Program()
        {
            CheckWord("program", true);
            var identifier = Identifier();
            
            CheckWord("(", true);
            var identifiersList = IdentifiersList(TokenType.RightParenthesis);
            CheckWord(")", true);
            
            CheckType(TokenType.Semicolon);

            return new Program(identifier, identifiersList);
        }

        public Identifier Identifier()
        {
            CheckType(TokenType.Identifier);

            return new Identifier(Next().Value);
        }

        public NonTerminal IdentifiersList(TokenType finalType)
        {
            var identifiers = new List<Identifier>();

            while (Peek().TokenType != finalType)
            {
                CheckType(TokenType.Identifier);
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
            throw new System.NotImplementedException();
        }

        public Declaration Declaration()
        {
            
            return null;
        }
    }
}