using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Program : NonTerminal
    {
        public Identifier ProgramIdentifier { get; }
        public NonTerminal IdentifierList { get; }
        public NonTerminal Declarations { get; }

        public Program(Identifier identifier, NonTerminal identifiers, NonTerminal declarations)
        {
            ProgramIdentifier = identifier;
            IdentifierList = identifiers;
            Declarations = declarations;
        }
    }
}