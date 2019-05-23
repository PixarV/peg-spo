using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Subprogram : NonTerminal
    {
        public NonTerminal SubprogramHead { get; }
        private NonTerminal _declarations;
        public NonTerminal CompoundStatements { get; }

        public Subprogram(NonTerminal subprogramHead, NonTerminal declarations, NonTerminal compoundStatements)
        {
            SubprogramHead = subprogramHead;
            _declarations = declarations;
            CompoundStatements = compoundStatements;
        }
    }
}