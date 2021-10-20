using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions
{
    class TriangularFunction:IMembershipFunction
    {
        public TriangularFunction(double left, double center, double right)
        {
            if(left > center || center > right)
                throw new ArgumentException("Wrong parameters for triangular function");
            this.left = left;
            this.center = center;
            this.right = right;
        }

        public double GetValue(double x)
        {
            if(x < left || x > right)
                return 0;
            if(x == center)
                return 1;
            if(x < center)
                return (x - left) / (center-left);
            return (right - x) / (right - center);
        }


        private double left, center, right;
    }
}
