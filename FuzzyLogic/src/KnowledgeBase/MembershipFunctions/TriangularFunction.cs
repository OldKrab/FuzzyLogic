using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class TriangularFunction : IFunction
    {
        public TriangularFunction(double left, double center, double right)
        {
            this.left = left;
            this.center = center;
            this.right = right;
        }

        public override string ToString()
        {
            return $"Triangular function with left={left}, center={center}, right={right}";
        }

        public double GetValue(double x)
        {
            if (x < left || x > right)
                return 0;
            if (Math.Abs(x - center) < 1e-6)
                return 1;
            if (x < center)
                return (x - left) / (center - left);
            return (right - x) / (right - center);
        }

        public double GetMinValue()
        {
            return left;
        }

        public double GetMaxValue()
        {
            return right;
        }


        private double left, center, right;
    }
}
