using System;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;

namespace FuzzyLogic.RuleParsers
{
    class SugenoRuleParser : IRuleParser
    {
        public void Parse(IRuleBuilder builder, string rule)
        {
            Console.WriteLine("Parsing use Sugeno RuleParser...");
        }

        public IOperationFactory OperationFactory { get; set; }
    }
}