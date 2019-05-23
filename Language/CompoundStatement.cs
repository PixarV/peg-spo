using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class CompoundStatement : NonTerminal
    {
        private List<NonTerminal> _optionalStatements;

        public CompoundStatement(List<NonTerminal> optionalStatements)
        {
            _optionalStatements = optionalStatements;
        }
    }
}