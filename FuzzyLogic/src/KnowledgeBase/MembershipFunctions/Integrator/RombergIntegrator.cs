using CenterSpace.NMath.Core;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    class RombergIntegrator : IFunctionIntegrator
    {
        public double Integrate(IMembershipFunction func, double lowerLimit, double upperLimit)
        {
            _serviceFunction = new OneVariableFunction(func.GetValue)
            {
                Integrator = new GaussKronrodIntegrator()
            };
            return _serviceFunction.Integrate(lowerLimit, upperLimit);
        }

        private OneVariableFunction _serviceFunction;
    }
}