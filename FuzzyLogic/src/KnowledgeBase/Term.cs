using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Term: NamedObject
    {
        public Term(string name, IFunction function) : base(name)
        {
            Function = function;  
        }

        public IFunction Function { get; }
    }
}
