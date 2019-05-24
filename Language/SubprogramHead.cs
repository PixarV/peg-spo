using System.Collections.Generic;

namespace HelloWorld.Language
{
    public enum SubprogramType
    {
        Function,
        Procedure
    }

    public class SubprogramHead : NonTerminal
    {
        public SubprogramType SubprogramType;
        public Identifier Identifier;
        public List<NonTerminal> Parameters;
        public Type ReturnType;

        public SubprogramHead(SubprogramType subprogramType, Identifier identifier, List<NonTerminal> parameters,
            Type returnType)
        {
            SubprogramType = subprogramType;
            Identifier = identifier;
            Parameters = parameters;
            ReturnType = returnType;
        }

        public SubprogramHead(SubprogramType subprogramType, Identifier identifier, List<NonTerminal> parameters)
        {
            SubprogramType = subprogramType;
            Identifier = identifier;
            Parameters = parameters;
        }
    }
}