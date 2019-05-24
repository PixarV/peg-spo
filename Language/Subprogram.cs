using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Subprogram : NonTerminal
    {
        public NonTerminal SubprogramHead { get; }
        private NonTerminal _declarations;
        public NonTerminal CompoundStatement { get; }

        public Subprogram(NonTerminal subprogramHead, NonTerminal declarations, NonTerminal compoundStatement)
        {
            SubprogramHead = subprogramHead;
            _declarations = declarations;
            CompoundStatement = compoundStatement;
        }
    }
}