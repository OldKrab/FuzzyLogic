using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public interface IFunction
    {
        double GetValue(double x);

        double GetMinValue();
        double GetMaxValue();

    }
}
