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
        public List<Declaration> Parameters;
        public Type ReturnType;

        public SubprogramHead(SubprogramType subprogramType, Identifier identifier, List<Declaration> parameters,
            Type returnType)
        {
            SubprogramType = subprogramType;
            Identifier = identifier;
            Parameters = parameters;
            ReturnType = returnType;
        }

        public SubprogramHead(SubprogramType subprogramType, Identifier identifier, List<Declaration> parameters)
        {
            SubprogramType = subprogramType;
            Identifier = identifier;
            Parameters = parameters;
        }
    }
}