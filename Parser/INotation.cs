using HelloWorld.Language;

namespace HelloWorld.Parser
{
    public interface INotation
    {
        NonTerminal Program();
        NonTerminal Id();
        NonTerminal IdentifiersList();
        NonTerminal Declarations();
    }
}