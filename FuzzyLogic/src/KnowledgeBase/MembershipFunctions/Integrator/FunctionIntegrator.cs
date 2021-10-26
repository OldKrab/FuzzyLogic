using CenterSpace.NMath.Core;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    class FunctionIntegrator : IFunctionIntegrator
    {
        public double Integrate(IMembershipFunction func, double lowerLimit, double upperLimit)
        {
            serviceFunction = new OneVariableFunction(func.GetValue);
            return serviceFunction.Integrate(lowerLimit, upperLimit);
        }

        private OneVariableFunction serviceFunction;
    }
}