using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.Operations
{
    class ProdOperation : IOperation
    {
        public double Evaluate(double x, double y)
        {
            return x * y;
        }
        public override string ToString()
        {
            return "Prod Operation";
        }
    }
}
