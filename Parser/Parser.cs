using System.Collections.Generic;
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


        public NonTerminal Program()
        {
            throw new System.NotImplementedException();
        }

        public NonTerminal Id()
        {
            throw new System.NotImplementedException();
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