using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;

namespace FuzzyLogic.RuleParsers
{
    interface IRuleParser
    {
        void Parse(IRuleBuilder builder, string rule);
        IOperationFactory OperationFactory { get; set; }
    }
}