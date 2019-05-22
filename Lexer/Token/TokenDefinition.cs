using System.Text.RegularExpressions;

namespace HelloWorld.Lexer.Token
{
    public class TokenDefinition
    {
        public Regex Regex { get; }
        public TokenType Type { get; }

        public TokenDefinition(Regex regex, TokenType type)
        {
            Regex = regex;
            Type = type;
        }
    }
}