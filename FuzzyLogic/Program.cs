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
                new Term("Slow", new TriangularFunction(0, 20, 40)),
                new Term("Medium", new TriangularFunction(20, 40, 60)),
                new Term("Fast", new TriangularFunction(40, 60, 80)),
            };
            var singleCond = new SingleCondition(variable, terms[0]);
            var condList = new ConditionList(singleCond);
            condList.AddCondition(new SingleCondition(variable, terms[2]), new MaxOperation());
            condList = new ConditionList(condList);
            condList.AddCondition(new SingleCondition(variable, terms[1]), new MinOperation());
            Console.WriteLine(singleCond);
            Console.WriteLine(condList);
            var input = new Dictionary<Variable, double> { { variable, 21 } };
            Console.WriteLine(singleCond.Fuzzify(input));
            Console.WriteLine(condList.Fuzzify(input));
        }
    }
}
