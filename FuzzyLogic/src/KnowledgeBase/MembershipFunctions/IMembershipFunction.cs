using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions
{
    interface IMembershipFunction
    {
        double GetValue(double x);
    }
}
