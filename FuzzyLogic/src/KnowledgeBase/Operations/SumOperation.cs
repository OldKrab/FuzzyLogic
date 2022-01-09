using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Operations
{
   public class SumOperation : IOrOperation
    {
        public double Evaluate(double x, double y)
        {
            return x + y;
        }

        public override string ToString()
        {
            return "Sum";
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
