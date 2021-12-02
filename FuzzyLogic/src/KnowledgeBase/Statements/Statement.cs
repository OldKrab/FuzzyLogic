using FuzzyLogic.KnowledgeBase.Helpers;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    abstract class Statement : IPrototype
    {
        protected Statement(Variable variable, Term term)
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
