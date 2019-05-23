using System.Collections.Generic;

namespace HelloWorld.Language
{
    public class CompoundStatement : NonTerminal
    {
        private List<NonTerminal> _statementList;

        public CompoundStatement(List<NonTerminal> statementList)
        {
            _statementList = statementList;
        }
    }
}