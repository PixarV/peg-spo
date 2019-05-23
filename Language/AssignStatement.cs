namespace HelloWorld.Language
{
    public class AssignStatement : NonTerminal
    {
        public Identifier VariableIdentifier { get; }
        public NonTerminal Expression { get;  }

        public AssignStatement(Identifier variableIdentifier, NonTerminal expression)
        {
            VariableIdentifier = variableIdentifier;
            Expression = expression;
        }
    }
}