using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Visitor
{
    public interface IKnowledgeVisitor
    {
        void Visit(SingleCondition condition);
        void Visit(ConditionList conditionList);
        void Visit(TrapezoidFunction trapezoidFunc);
        void Visit(TriangularFunction triangularFunc);
        void Visit(LinearFunction triangularFunction);
        void Visit(MinOperation op);
        void Visit(MaxOperation op);
        void Visit(ProdOperation op);
        void Visit(SumOperation op);
    }
}