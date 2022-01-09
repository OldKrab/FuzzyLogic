using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    public class ProdOperation : IAndOperation
    {
        public double Evaluate(double x, double y)
        {
            return x * y;
        }
        public override string ToString()
        {
            return "Prod";
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
