namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    interface IFunctionIntegrator
    {
        double Integrate(IFunction func, double lowerLimit, double upperLimit);
    }
}