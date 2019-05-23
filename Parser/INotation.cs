using HelloWorld.Language;
using HelloWorld.Lexer.Token;

namespace HelloWorld.Parser
{
    public interface INotation
    {
        NonTerminal Program();
        Identifier Identifier();
        NonTerminal IdentifierList(TokenType finalType);
        NonTerminal Declarations();
        Declaration Declaration();
        Type Type();
        NonTerminal SubprogramDeclarations();
        Subprogram Subprogram(SubprogramType type);
        NonTerminal SubprogramHead(SubprogramType subprogramType);
        NonTerminal CompoundStatements();
    }
}