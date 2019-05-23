namespace HelloWorld.Language
{
    public class ArrayType : Type
    {
        public int LowerBound { get; }
        public int UpperBound { get; }

        public ArrayType(string type, int lowerBound, int upperBound) : base(type)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
    }
}