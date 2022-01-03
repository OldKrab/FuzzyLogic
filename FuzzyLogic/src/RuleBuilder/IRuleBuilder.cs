using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.RuleBuilder
{
    interface IRuleBuilder
    {
        IRuleBuilder AddCondition(Variable var, Term term);
        IRuleBuilder AddOperation(IOperation operation);
        IRuleBuilder StartConditionList();
        IRuleBuilder EndConditionList();
        IRuleBuilder AddConclusion(Variable var, Term term);
        IRuleBuilder Clear();
    }
}