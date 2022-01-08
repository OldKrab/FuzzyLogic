namespace FuzzyLogic.KnowledgeBase.Visitor
{
    public interface IVisitableElement
    {
        void Accept(IKnowledgeVisitor visitor);
    }
}