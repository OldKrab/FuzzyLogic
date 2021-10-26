using System;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator;

namespace FuzzyLogic
{
    class Program
    {
        static void Main()
        {
            var triangularFunc = new TriangularFunction(0, 1, 2);
            var integrator = new FunctionIntegrator();
            Console.WriteLine(integrator.Integrate(triangularFunc, 0,1));
        }
    }
}
