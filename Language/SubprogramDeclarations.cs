using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class SubprogramDeclarations : NonTerminal
    {
        private List<NonTerminal> _subprograms;

        public SubprogramDeclarations(List<NonTerminal> subprograms)
        {
            _subprograms = subprograms;
        }
    }
}