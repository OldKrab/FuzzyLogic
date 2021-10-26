using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Term: NamedObject
    {
        public Term(string name, IMembershipFunction function) : base(name)
        {
            MembershipFunction = function;  
        }

        public IMembershipFunction MembershipFunction { get; }
    }
}
