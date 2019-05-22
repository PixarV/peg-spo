namespace HelloWorld.Lexer.Token
{
    public class TokenDefinition
    {
        public string Regexp { get; }
        public TokenType Type { get; }

        public TokenDefinition(string regexp, TokenType type)
        {
            Regexp = regexp;
            Type = type;
        }
    }
}