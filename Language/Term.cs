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
        public NonTerminal Factor { get; }
        public MulOperation MulOperation { get; }

        public SimpleTerm(NonTerminal factor, MulOperation mulOperation)
        {
            Factor = factor;
            MulOperation = mulOperation;
        }
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