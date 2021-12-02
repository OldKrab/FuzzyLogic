using System.Runtime.InteropServices.WindowsRuntime;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class LinearFunction : IFunction
    {
        public LinearFunction(float a, float b, bool isIncrease)
        {
            this.a = a;
            this.b = b;
            this.isIncrease = isIncrease;
        }
        public double GetValue(double x)
        {
            if (isIncrease)
            {
                if (x < a)
                    return 0;
                if (x < b)
                    return (x - a) / (b - a);
                return 1;
            }
            else
            {
                if (x < a)
                    return 1;
                if (x < b)
                    return (b - x) / (b - a);
                return 0;
            }
        }

        public double GetMinValue()
        {
            return a;
        }

        public double GetMaxValue()
        {
            return b;
        }

        private float a, b;
        private bool isIncrease;


    }
}