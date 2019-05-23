using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class SubprogramDeclarations : NonTerminal
    {
        private List<Subprogram> _subprograms;

        public SubprogramDeclarations(List<Subprogram> subprograms)
        {
            _subprograms = subprograms;
        }
    }
}