namespace HelloWorld.Language
{
    public class ArrayType : Type
    {
        public int UpperBound { get; }
        public int LowerBound { get; }

        public ArrayType(string type, int upperBound, int lowerBound) : base(type)
        {
            UpperBound = upperBound;
            LowerBound = lowerBound;
        }
    }
}