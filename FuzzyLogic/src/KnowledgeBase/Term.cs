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

        public string Name { get; }
        public IFunction Function { get; }
    }
}
