namespace HelloWorld.Language
{
    public class Identifier : NonTerminal
    {
        public Identifier(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}