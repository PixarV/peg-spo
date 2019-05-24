using System.Collections.Generic;

namespace HelloWorld.Language
{
    public enum AddOpertaion
    {
        Add,
        Sub,
        None
    }

    public struct Simple
    {
        public NonTerminal Term { get; }
        public AddOpertaion AddOpertaion { get; }
    }

    public class SimpleExpression : NonTerminal
    {
        private List<Simple> _simples;

        public SimpleExpression(List<Simple> simples)
        {
            _simples = simples;
        }
    }
}