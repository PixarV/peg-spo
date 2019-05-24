namespace HelloWorld.Language
{
    public enum RelationOp
    {
        More,
        Less,
        None
    }
    
    public class Expression : NonTerminal
    {
        public NonTerminal First { get; }
        public NonTerminal Second { get; }
        public RelationOp RelationOp { get; }

        public Expression(NonTerminal first, NonTerminal second, RelationOp relationOp)
        {
            First = first;
            Second = second;
            RelationOp = relationOp;
        }
    }
}