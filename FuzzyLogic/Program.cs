using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.KnowledgeBaseManager;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic
{

    class Program
    {
        private static void PrintFunction(IMembershipFunction func, double start, double end, double stepCount)
        {
            for (int step = 0; step < stepCount; step++)
            {
                double x = start + (end - start) * (step / (stepCount - 1));
                Console.Write("({0:N2}, {1:N2}) ", x, func.GetValue(x));
            }
            Console.WriteLine();
        }

        private static void Main()
        {
            IMembershipFunction triangularFunc = new TriangularFunction(0, 1, 2);
            Console.Write($"Created {triangularFunc}\nHis values: ");
            PrintFunction(triangularFunc, 0, 2, 8);
            var activatedFunc = new ActivatedFunction(triangularFunc, new MinOperation(), 0.5);
            Console.Write($"\nCreated {activatedFunc}\nHis values: ");
            PrintFunction(activatedFunc, 0, 2, 8);
            var activatedFunc2 = new ActivatedFunction(activatedFunc, new ProdOperation(), 0.5);
            Console.Write($"\nCreated {activatedFunc2}\nHis values: ");
            PrintFunction(activatedFunc2, 0, 2, 8);
        }
    }
}
