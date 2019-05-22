using System;
using System.Collections.Generic;
using System.IO;
using HelloWorld.Lexer.Token;

//using HelloWorld.Lexer.Token;

namespace HelloWorld.Lexer
{
    public class Lexer
    {
        List<Token.Token> _tokens = new List<Token.Token>();

        List<TokenDefinition> _definitions;

        public Lexer(List<TokenDefinition> definitions)
        {
            _definitions = definitions;
        }


        public List<Token.Token> Tokenize(string path)
        {
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                MatchDefinitionInLine(line);
            }


            Console.WriteLine("hey");
            return _tokens;
        }

        private void MatchDefinitionInLine(string line)
        {
            while (line.Length != 0)
            {
                bool isMatched = false;
                foreach (var definition in _definitions)
                {
                    var match = definition.Regex.Match(line, 0);
                    if (!match.Success) continue;

                    var value = match.Value;
                    _tokens.Add(new Token.Token(definition.Type, value.Trim()));
                    line = line.Substring(value.Length);
                    isMatched = true;
                    break;
                }

                if (!isMatched) throw new InvalidDataException("cannont be parse");
            }
        }
    }
}