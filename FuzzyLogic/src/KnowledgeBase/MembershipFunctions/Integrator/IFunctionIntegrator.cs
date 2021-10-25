namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions.Integrator
{
    interface IFunctionIntegrator
    {
        double Integrate(IMembershipFunction func, double lowerLimit, double upperLimit);
    }
}