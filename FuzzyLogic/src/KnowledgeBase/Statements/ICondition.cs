using System.Collections.Generic;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    interface ICondition
    {
        double Fuzzify(Dictionary<Variable, double> inputValues);
    }
}