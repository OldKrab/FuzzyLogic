using System;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    class MaxOperation : OrOperation
    {
        public double Evaluate(double x, double y)
        {
            return Math.Max(x, y);
        }
        public override string ToString()
        {
            return "Max";
        }
    }
}
