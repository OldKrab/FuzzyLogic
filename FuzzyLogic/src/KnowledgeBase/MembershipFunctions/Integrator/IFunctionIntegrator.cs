namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    interface IFunctionIntegrator
    {
        double Integrate(IMembershipFunction func, double lowerLimit, double upperLimit);
    }
}