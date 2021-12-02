using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.FuzzyAlgorithm
{
class Activator
{
    public Dictionary<Conclusion, IFunction> Activate(Dictionary<Rule, double> fuzzifiedValues, IOperation operation)
    {
        var activatedFunctions = new Dictionary<Conclusion, IFunction>();
        foreach (var it in fuzzifiedValues)
        {
            var rule = it.Key;
            var activatingValue = it.Value;
            foreach (var conclusion in rule.Conclusions)
            {
                activatedFunctions.Add(conclusion, new ActivatedFunction(conclusion.Term.Function,
                    operation, activatingValue));
            }
        }

        return activatedFunctions;
    }
}
}