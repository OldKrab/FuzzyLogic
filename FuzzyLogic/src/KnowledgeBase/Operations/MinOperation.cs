using System;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    class MinOperation : AndOperation
    {
        public double Evaluate(double x, double y)
        {
            return Math.Min(x, y);
        }

        public override string ToString()
        {
            return "Min";
        }
    }
}
