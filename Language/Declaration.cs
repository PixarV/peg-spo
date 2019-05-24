namespace HelloWorld.Language
{
    public class Declaration : NonTerminal
    {
        public NonTerminal IdentifierList { get; }
        public Type Type { get; }

        public Declaration(NonTerminal identifierList, Type type)
        {
            IdentifierList = identifierList;
            Type = type;
        }
    }
}