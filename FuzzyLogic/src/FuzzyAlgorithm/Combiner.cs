using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.FuzzyAlgorithm
{
    class Combiner
    {
        public Dictionary<Variable, IFunction> Combine(Dictionary<Conclusion, IFunction> activatedFunctions, IOperation combinationOp)
        {
            var functions = new Dictionary<Variable, List<IFunction>>();
            foreach (var it in activatedFunctions)
            {
                var conclusion = it.Key;
                var function = it.Value;
                if (!functions.ContainsKey(conclusion.Variable))
                    functions.Add(conclusion.Variable, new List<IFunction>());
                functions[conclusion.Variable].Add(function);
            }

            var combinedFunctions = new Dictionary<Variable, IFunction>();
            foreach (var it in functions)
                combinedFunctions.Add(it.Key, new CombinedFunction(combinationOp, it.Value));

            return combinedFunctions;
        }
    }
}