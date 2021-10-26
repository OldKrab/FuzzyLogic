using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class TriangularFunctionProxy : IMembershipFunction
    {
        public TriangularFunctionProxy(double left, double center, double right)
        {
            if (left > center || center > right)
                throw new ArgumentException(
                    $"Can't create triangular function! Wrong parameters order: {left}, {center}, {right}");
            triangularFunction = new TriangularFunction(left, center, right);
            Console.WriteLine("Created triangular function with parameters: {0}, {1}, {2}", left, center, right);
        }

        public double GetValue(double x)
        {
            if (double.IsNaN(x))
                throw new ArgumentException("Can't get value from triangular function! x is NaN");
            return triangularFunction.GetValue(x);
        }

        private TriangularFunction triangularFunction;
    }
}
