using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Term
    {
        public Term(string name, IFunction function)
        {
            Name = name;
            Function = function;  
        }

        public override string ToString()
        {
            return $"Term {Name} with function \"{Function}\"";
        }

        public string Name { get; }
        public IFunction Function { get; }
    }
}
