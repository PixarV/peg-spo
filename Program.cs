using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HelloWorld.Lexer;
using HelloWorld.Lexer.Token;
using static HelloWorld.Lexer.Token.TokenType;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitions = new List<TokenDefinition>();
            definitions.Add(new TokenDefinition(new Regex(@"^\s*(program|var|array|of|function|procedure)\s*"), Keyword));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*(integer|real)\s*"), TokenType.Type));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*[_a-zA-Z][_a-zA-Z0-9]*\s*"), Identifier));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*[-+]?\d+\s*"), Num));
            definitions.Add(new TokenDefinition(new Regex(@"^\("), LeftParenthesis));
            definitions.Add(new TokenDefinition(new Regex(@"^\["), LeftBracket));
            definitions.Add(new TokenDefinition(new Regex(@"^\)"), RightParenthesis));
            definitions.Add(new TokenDefinition(new Regex(@"^\]"), RightBracket));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*;\s*"), Semicolon));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*,\s*"), Comma));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*:\s*"), Colon));
            definitions.Add(new TokenDefinition(new Regex(@"^\s*..\s*"), Dots));
            
            var lexer = new Lexer.Lexer(definitions);
            var tokenize = lexer.Tokenize("resources/first");
            Console.WriteLine("hhh");
        }
    }
}
