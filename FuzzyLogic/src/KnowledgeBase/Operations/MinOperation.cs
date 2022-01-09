using System;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Operations
{
   public class MinOperation : IAndOperation
    {
        public double Evaluate(double x, double y)
        {
            return Math.Min(x, y);
        }

        public override string ToString()
        {
            return "Min";
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
