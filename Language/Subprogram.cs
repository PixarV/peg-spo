using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Subprogram : NonTerminal
    {
        public NonTerminal SubprogramHead { get; }
        private NonTerminal _declarations;

        public Subprogram(NonTerminal subprogramHead, NonTerminal declarations)
        {
            SubprogramHead = subprogramHead;
            _declarations = declarations;
        }
    }
}