using System.Collections.Generic;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    class SingleCondition : Statement, ICondition
    {
        public SingleCondition(Variable variable, Term term)
            : base(variable, term) { }



        public double Fuzzify(Dictionary<Variable, double> inputValues)
        {
            return Term.Function.GetValue(inputValues[this.Variable]);
        }
    }
}