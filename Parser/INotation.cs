using HelloWorld.Language;

namespace HelloWorld.Parser
{
    public interface INotation
    {
        NonTerminal Program();
        Identifier Id();
        NonTerminal IdentifiersList();
        NonTerminal Declarations();
    }
}