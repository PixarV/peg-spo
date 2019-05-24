using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Declarations : NonTerminal
    {
        private List<NonTerminal> _declarations;

        public Declarations(List<NonTerminal> declarations)
        {
            _declarations = declarations;
        }
    }
}