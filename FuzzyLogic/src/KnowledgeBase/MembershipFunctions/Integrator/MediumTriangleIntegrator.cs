namespace FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator
{
    class MediumTriangleIntegrator : IFunctionIntegrator
    {
        public double Integrate(IFunction func, double lowerLimit, double upperLimit)
        {
            double interval = upperLimit - lowerLimit;
            double xPrev = lowerLimit;
            double res = 0;
            for (int i = 1; i < cntOfDots; i++)
            {
                double x = lowerLimit + (double)i / (cntOfDots - 1) * interval;
                double h = x - xPrev;
                res += func.GetValue(x + h / 2) * h;
                xPrev = x;
            }
            return res;
        }

        private int cntOfDots = 1000;
    }
}