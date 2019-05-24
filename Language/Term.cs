using System.Collections.Generic;

namespace HelloWorld.Language
{
    public enum MulOperation
    {
        Mul,
        Div,
        None
    }
    
    public struct SimpleTerm
    {
        public NonTerminal factor { get; }
        public MulOperation MulOperation { get; }
    }
    
    public class Term : NonTerminal
    {
        private List<SimpleTerm> _simpleTerms;

        public Term(List<SimpleTerm> simpleTerms)
        {
            _simpleTerms = simpleTerms;
        }
    }
}