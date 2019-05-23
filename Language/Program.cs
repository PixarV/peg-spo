using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Program : NonTerminal
    {
        public NonTerminal IdentifierList { get; }
        public Identifier ProgramIdentifier { get; }
        public Program(Identifier identifier, NonTerminal identifiers)
        {
            ProgramIdentifier = identifier;
            IdentifierList = identifiers;
        }

        
    }
}