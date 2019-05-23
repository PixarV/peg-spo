namespace HelloWorld.Language
{
    public enum StatementType
    {
        Assign,
        Compound,
        If,
        While
    }


    public class Statement<T> where T : NonTerminal
    {
        public StatementType StatementType { get; }
        public T TrueStatement { get; }

        public Statement(StatementType statementType, T statement)
        {
            StatementType = statementType;
            TrueStatement = statement;
        }
    }
}