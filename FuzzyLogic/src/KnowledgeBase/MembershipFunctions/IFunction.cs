﻿using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public interface IFunction: IVisitableElement
    {
        double GetValue(double x);

        double GetMinValue();
        double GetMaxValue();

    }
}
