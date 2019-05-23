using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class IdentifierList : NonTerminal
    {
        private List<Identifier> _identifiers;

        public IdentifierList(List<Identifier> identifiers)
        {
            _identifiers = identifiers;
        }
    }
}