using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
     class TrapezoidFunction:IFunction
    {
        public TrapezoidFunction(double left, double leftCenter, double rightCenter, double right)
        {
            this.left = left;
            this.leftCenter = leftCenter;
            this.rightCenter = rightCenter;
            this.right = right;
        }

        public override string ToString()
        {
            return $"Trapezoid function with left={left}, leftCenter={leftCenter}, rightCenter={rightCenter}, right={right}";
        }

        public double GetValue(double x)
        {
            if (x < left || x > right)
                return 0;
            if (Math.Abs(x - leftCenter) < 1e-6 || Math.Abs(x - rightCenter) < 1e-6 || leftCenter < x && x < rightCenter)
                return 1;
            if (x < leftCenter)
                return (x - left) / (leftCenter - left);
            return (right - x) / (right - rightCenter);
        }

        public double GetMinValue()
        {
            return left;
        }

        public double GetMaxValue()
        {
            return right;
        }


        private double left, leftCenter, rightCenter, right;
    }
}