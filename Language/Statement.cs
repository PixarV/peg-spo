namespace HelloWorld.Language
{
    public enum StatementType
    {
        Assign,
        Compound,
        If,
        While
    }


    public class Statement : NonTerminal
    {
        public StatementType StatementType { get; }
        
        public Statement(StatementType statementType)
        {
            StatementType = statementType;
        }
    }
}