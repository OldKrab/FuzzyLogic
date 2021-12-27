using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    interface ICondition:IPrototype,IVisitableElement
    {
        double Fuzzify(Dictionary<Variable, double> inputValues);
    }
}