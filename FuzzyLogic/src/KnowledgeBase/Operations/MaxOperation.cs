using System;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Operations
{
   public  class MaxOperation : IOrOperation
    {
        public double Evaluate(double x, double y) => Math.Max(x, y);

        public override string ToString() => "Max";

        public void Accept(IKnowledgeVisitor visitor) => visitor.Visit(this);
    }
}
