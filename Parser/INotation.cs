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
        NonTerminal Declaration();
        Type Type();
        NonTerminal SubprogramDeclarations();
        NonTerminal Subprogram(SubprogramType type);
        NonTerminal SubprogramHead(SubprogramType subprogramType);
        NonTerminal CompoundStatement();
        NonTerminal Statement();
        NonTerminal Expression();
        NonTerminal SimpleExpression();
        NonTerminal Term();
        NonTerminal Factor();

    }
}