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

        private bool checkWord(string word)
        {
            var token = Peek();
            if (!token.Value.Equals(word))
                throw new InvalidDataException("missing " + word);

            return true;
        }

        private bool checkType(TokenType type)
        {
            var token = Peek();
            if (!token.TokenType.Equals(type))
                throw new InvalidDataException("doesnt match type " + type);

            return true;
        }

        public NonTerminal Program()
        {
            if (IsEnd()) throw new InvalidDataException("empty token list");

            checkWord("program");
            Eat();
            var identifier = Id();
            var identifiersList = IdentifiersList();

            return new Program(identifier, identifiersList);
        }

        public Identifier Id()
        {
            checkType(TokenType.Identifier);

            return new Identifier(Next().Value);
        }

        public NonTerminal IdentifiersList()
        {
            throw new System.NotImplementedException();
        }

        public NonTerminal Declarations()
        {
            throw new System.NotImplementedException();
        }
    }
}