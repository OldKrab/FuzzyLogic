using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.Operations
{
    class MinOperation : IOperation
    {
        public double Evaluate(double x, double y)
        {
            return Math.Min(x, y);
        }
    }
}
