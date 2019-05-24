namespace HelloWorld.Language
{
    public enum RelOperation
    {
        More,
        Less,
        None
    }
    
    public class Expression : NonTerminal
    {
        public NonTerminal First { get; }
        public NonTerminal Second { get; }
        public RelOperation RelOperation { get; }

        public Expression(NonTerminal first, NonTerminal second, RelOperation relOperation)
        {
            First = first;
            Second = second;
            RelOperation = relOperation;
        }
    }
}