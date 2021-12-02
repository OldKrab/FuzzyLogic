namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    interface IFunction
    {
        double GetValue(double x);

        double GetMinValue();
        double GetMaxValue();

    }
}
