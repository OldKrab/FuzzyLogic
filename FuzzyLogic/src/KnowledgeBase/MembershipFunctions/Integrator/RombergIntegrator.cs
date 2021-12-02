using CenterSpace.NMath.Core;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    class RombergIntegrator : IFunctionIntegrator
    {
        public double Integrate(IFunction func, double lowerLimit, double upperLimit)
        {
            serviceFunction = new OneVariableFunction(func.GetValue);
            return serviceFunction.Integrate(lowerLimit, upperLimit);
        }

        private OneVariableFunction serviceFunction;
    }
}