using HelloWorld.Language;
using HelloWorld.Lexer.Token;

namespace HelloWorld.Parser
{
    public interface INotation
    {
        NonTerminal Program();
        Identifier Identifier();
        NonTerminal IdentifiersList(TokenType finalType);
        NonTerminal Declarations();
        Declaration Declaration();
    }
}