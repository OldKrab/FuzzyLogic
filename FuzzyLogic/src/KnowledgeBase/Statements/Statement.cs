namespace FuzzyLogic.KnowledgeBase.Statements
{
    public  class Statement
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

      
    }
}
