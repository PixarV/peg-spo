using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class Declarations : NonTerminal
    {
        private List<Declaration> _declarations;

        public Declarations(List<Declaration> declarations)
        {
            _declarations = declarations;
        }
    }
}