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
            var variable = new Variable("Speed");

            var terms = new List<Term>
    {
        new Term("Slow", new TrapezoidFunction(0, 0, 20, 40)),
        new Term("Medium", new TriangularFunction(20, 40, 60)),
        new Term("Fast", new TrapezoidFunction(40, 60, 180, 180)),
    };

            var singleConds = new List<SingleCondition>
    {
        new SingleCondition(variable, terms[0]),
        new SingleCondition(variable, terms[1]),
        new SingleCondition(variable, terms[2])
    };

            var condList = new ConditionList
            (
                new ConditionList(
                    new List<ICondition>
                    {
                singleConds[0],
                singleConds[2]
                    },
                    new List<IOperation>
                    {
                new MaxOperation()
                    })
            );
            condList.AddCondition(singleConds[1], new MinOperation());

            Console.WriteLine($"Current variable: {variable}");

            Console.WriteLine("\nCurrent terms:");
            foreach (var term in terms)
                Console.WriteLine($"{term}, {term.MembershipFunction}");

            Console.WriteLine("\nCurrent conditions:");
            foreach (var cond in singleConds)
                Console.WriteLine(cond + ",");
            Console.WriteLine(condList);

            Console.Write($"\nInput value for variable {variable}: ");
            var input = new Dictionary<Variable, double> { { variable, Convert.ToInt32(Console.ReadLine()) } };

            Console.WriteLine("\nFuzzification for current conditions:");
            foreach (var cond in singleConds)
                Console.WriteLine(cond.Fuzzify(input));
            Console.WriteLine(condList.Fuzzify(input));
        }
    }
}
