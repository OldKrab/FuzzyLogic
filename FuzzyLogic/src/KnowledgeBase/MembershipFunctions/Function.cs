using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class Function : IFunction
    {
        public Function(Func<double, double> func, double min, double max)
        {
            this.func = func;
            this.max = max;
            this.min = min;
        }

        public double GetValue(double x)
        {
            return func(x);
        }

        public double GetMinValue()
        {
            return min;
        }

        public double GetMaxValue()
        {
            return max;
        }

        private Func<double, double> func;
        private double min, max;
    }
}