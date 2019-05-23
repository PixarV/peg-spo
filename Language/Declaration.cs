namespace HelloWorld.Language
{
    public class Declaration
    {
        public IdentifierList IdentifierList { get; }
        public string Type { get; }

        public Declaration(IdentifierList identifierList, string type)
        {
            IdentifierList = identifierList;
            this.Type = type;
        }
    }
}