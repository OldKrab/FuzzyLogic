using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.Operations
{
    class MaxOperation : IOperation
    {
        public double Evaluate(double x, double y)
        {
            return Math.Max(x, y);
        }
        public override string ToString()
        {
            return "Max Operation";
        }
    }
}
