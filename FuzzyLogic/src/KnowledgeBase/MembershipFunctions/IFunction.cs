using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    interface IFunction: IVisitableElement
    {
        double GetValue(double x);

        double GetMinValue();
        double GetMaxValue();

    }
}
