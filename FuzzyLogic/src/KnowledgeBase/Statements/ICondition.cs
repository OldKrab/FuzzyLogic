using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Helpers;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    interface ICondition:IPrototype
    {
        double Fuzzify(Dictionary<Variable, double> inputValues);
    }
}