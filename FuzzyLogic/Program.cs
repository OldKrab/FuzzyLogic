using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.src.KnowledgeBase.Operations;
using System;

namespace FuzzyLogic
{
class Program
{
    static void PrintFunction(IMembershipFunction function, double start, double end, double stepCount)
    {
        for(int step = 0; step < stepCount; step++)
        {
            double x = start + (end-start)*(step/(stepCount-1));
            System.Console.Write("{0:N3} ", function.GetValue(x));
        }
        System.Console.WriteLine();
    }

    static void Main(string[] args)
    {
        double start = 0, center = 10, end = 20, activatingValue = 0.45;
        int stepCount = 20;

        var triangularFunction = new TriangularFunction(start, center, end);
        var activatedFunction = new ActivatedFunction(triangularFunction, new MinOperation(), activatingValue);
        var combinedFunction = new CombinedFunction(new SumOperation(), triangularFunction);
        combinedFunction.AddFunction(activatedFunction);

        System.Console.WriteLine("original function:");
        PrintFunction(triangularFunction, start, end, stepCount);
        System.Console.WriteLine("activated function:");
        PrintFunction(activatedFunction, start, end, stepCount);
        System.Console.WriteLine("combined function:");
        PrintFunction(combinedFunction, start, end, stepCount);
    }
}
}
