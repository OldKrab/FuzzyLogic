using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.RuleBuilders;

namespace FuzzyLogic.RuleParsers
{
    public interface IRuleParser
    {
        void Parse(IRuleBuilder builder, string rule);
        IOperationFactory OperationFactory { get; set; }
    }
}