using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Program : NonTerminal
    {
        public Identifier ProgramIdentifier { get; }
        public NonTerminal IdentifierList { get; }
        public NonTerminal Declarations { get; }
        public NonTerminal SubprogramDeclarations { get; }
        
        

        public Program(Identifier identifier, NonTerminal identifiers, NonTerminal declarations, NonTerminal subprogramDeclarations)
        {
            ProgramIdentifier = identifier;
            IdentifierList = identifiers;
            Declarations = declarations;
            SubprogramDeclarations = subprogramDeclarations;
        }
    }
}