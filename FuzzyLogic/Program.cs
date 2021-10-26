using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic
{
class Program
{
    static void Main()
    {
        var triangularFunc = new TriangularFunction(0, 1, 2);
        Console.WriteLine($"Created {triangularFunc}");
        var integrator = new FunctionIntegrator();
        Console.WriteLine($"His integral on range [0, 2] = {integrator.Integrate(triangularFunc, 0,2)}");
        Console.WriteLine($"His integral on range [1, 2] = {integrator.Integrate(triangularFunc, 1,2)}");
        var activatedFunc = new ActivatedFunction(triangularFunc, new MinOperation(), 0.5);
        Console.WriteLine($"\nCreated {activatedFunc}");
        Console.WriteLine($"His integral on range [0, 2] = {integrator.Integrate(activatedFunc, 0,2)}");
        Console.WriteLine($"His integral on range [1, 2] = {integrator.Integrate(activatedFunc, 1,2)}");
        var  combinedFunc= new CombinedFunction(new SumOperation(), new List<IMembershipFunction>{triangularFunc, activatedFunc});
        Console.WriteLine($"\nCreated {combinedFunc}");
        Console.WriteLine($"His integral on range [0, 2] = {integrator.Integrate(combinedFunc, 0,2)}");
        Console.WriteLine($"His integral on range [1, 2] = {integrator.Integrate(combinedFunc, 1,2)}");
    }
}
}
