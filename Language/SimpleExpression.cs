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

        public Simple(NonTerminal term, AddOpertaion addOpertaion)
        {
            Term = term;
            AddOpertaion = addOpertaion;
        }
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