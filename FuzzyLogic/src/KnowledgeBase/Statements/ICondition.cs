using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    public interface ICondition:IVisitableElement
    {
        double Fuzzify(Dictionary<Variable, double> inputValues);
    }
}