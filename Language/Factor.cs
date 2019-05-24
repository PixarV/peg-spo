namespace HelloWorld.Language
{
    public enum FactorType
    {
        Id,
        Num,
        Exp,
        Not
    }
    
    public class Factor : NonTerminal
    {
        public FactorType Type { get; }
        public Identifier Identifier { get; }
        public string Digit { get; }
        public NonTerminal Expression { get; }

        public Factor(FactorType type, Identifier identifier)
        {
            Type = type;
            Identifier = identifier;
        }

        public Factor(FactorType type, string digit)
        {
            Type = type;
            Digit = digit;
        }

        public Factor(FactorType type, NonTerminal expression)
        {
            Type = type;
            Expression = expression;
        }
    }
}