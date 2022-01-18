using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    public class Term
    {
        public Term(string name, IMembershipFunction function)
        {
            Name = name;
            Function = function;  
        }

        public override string ToString()
        {
            return $"Терм \"{Name}\" с функцией принадлежности \"{Function}\"";
        }

        public string Name { get; }
        public IMembershipFunction Function { get; }
    }
}
