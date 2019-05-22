using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HelloWorld.Lexer;
using HelloWorld.Lexer.Token;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitions = new List<TokenDefinition>();
            definitions.Add(new TokenDefinition(new Regex("^\\s*program\\s*"), TokenType.Keyword));
            definitions.Add(new TokenDefinition(new Regex("^\\s*[_a-zA-Z][_a-zA-Z0-9]*\\s*"), TokenType.Identifier));
            definitions.Add(new TokenDefinition(new Regex("^\\("), TokenType.LeftParenthesis));
            definitions.Add(new TokenDefinition(new Regex("^\\)"), TokenType.RightParenthesis));
            definitions.Add(new TokenDefinition(new Regex("^\\s*;\\s*"), TokenType.Semicolon));
            
            var lexer = new Lexer.Lexer(definitions);
            var tokenize = lexer.Tokenize("resources/first");
            
        }
    }
}
