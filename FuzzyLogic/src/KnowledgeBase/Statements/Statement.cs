using FuzzyLogic.KnowledgeBase.Helpers;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    public  class Statement : IPrototype
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
            return new Statement((Variable)Variable.Clone(), Term);
        }
    }
}
