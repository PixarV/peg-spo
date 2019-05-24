namespace HelloWorld.Language
{
    public class AssignStatement : Statement
    {
        public Identifier VariableIdentifier { get; }
        public NonTerminal Expression { get;  }

        public AssignStatement(StatementType statementType, Identifier variableIdentifier, NonTerminal expression) : base(statementType)
        {
            VariableIdentifier = variableIdentifier;
            Expression = expression;
        }
    }
}