namespace FuzzyLogic.KnowledgeBase.Visitor
{
     interface IVisitableElement
    {
        void Accept(IKnowledgeVisitor visitor);
    }
}