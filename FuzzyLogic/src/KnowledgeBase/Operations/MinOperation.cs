using System;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    class MinOperation : IOperation
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
