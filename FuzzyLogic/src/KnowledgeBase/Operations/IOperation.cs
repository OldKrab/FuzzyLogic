using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.Operations
{
    interface IOperation
    {
        double Evaluate(double x, double y);
    }
}
