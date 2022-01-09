using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    public interface IOperation : IVisitableElement
    {
        double Evaluate(double x, double y);
    }
}
