using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.FuzzyAlgorithm
{
    class Fuzzifier
    {
        public Dictionary<Rule, double> Fuzzify(Dictionary<Variable, double> inputValues, List<Rule> rules)
        {
            return rules.Select(rule => new { rule, value = rule.Condition.Fuzzify(inputValues) })
                .ToDictionary(it => it.rule, it => it.value);
        }
    }
}