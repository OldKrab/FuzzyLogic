using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Statements
{
     class Statement : IPrototype
    {
        public Statement(Variable variable, Term term)
        {
            Term = term;
            Variable = variable;
        }

        public Term Term { get; }
        public Variable Variable { get; }

        public override string ToString()
        {
            return $"{Variable} is {Term}";
        }

        public IPrototype Clone()
        {
            return (Statement)MemberwiseClone();
        }
    }
}
