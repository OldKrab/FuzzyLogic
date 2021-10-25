using System;
using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.KnowledgeBaseManager;
using FuzzyLogic.src.KnowledgeBase.MembershipFunctions.Integrator;

namespace FuzzyLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangularFunc = new TriangularFunction(0, 1, 2);
            var integrator = new FunctionIntegrator();
            Console.WriteLine(integrator.Integrate(triangularFunc, 0,1));
        }
    }
}
