using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.src.KnowledgeBase.Operations;
using System;

namespace FuzzyLogic
{
    class Program
    {
        static void PrintFunction(IMembershipFunction function, double start, double end, double stepCount)
        {
            for (int step = 0; step < stepCount; step++)
            {
                double x = start + (end - start) * (step / (stepCount - 1));
                Console.Write("{0:N3} ", function.GetValue(x));
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            double start = 0, center = 10, end = 20;
            int stepCount = 20;

            Console.WriteLine("# Test 1: Create right triangular function proxy");
            var triangularFunction = new TriangularFunctionProxy(start, center, end);
            Console.WriteLine("proxy function values:");
            PrintFunction(triangularFunction, start, end, stepCount);

            Console.WriteLine("\n# Test 2: Calculate function value in NaN point");
            try
            {
                triangularFunction.GetValue(double.NaN);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n# Test 3: Create triangular function proxy with wrong parameters");
            try
            {
                center = 30;
                triangularFunction = new TriangularFunctionProxy(start, center, end);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
