using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilders;

namespace FuzzyLogic.KnowledgeBase.RuleParsers
{
    public interface IRuleParser
    {
        void Parse(IRuleBuilder builder, string rule);
        IOperationFactory OperationFactory { get; set; }
    }
}