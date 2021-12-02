using System;
using System.Collections.Generic;
using System.Globalization;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.KnowledgeBaseManager;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic
{
    class Program
    {
        private static Rule CreateRule(Variable var1, string term1, IOperation op, Variable var2, string term2, Variable outVar, string outTerm)
        {
            return new Rule(
                new ConditionList(
                    new List<ICondition>
                    {
                    new SingleCondition(var1, var1.GetTerm(term1)),
                    new SingleCondition(var2, var2.GetTerm(term2))
                    },
                    new List<IOperation>
                    {
                    op
                    }),
                new List<Conclusion>
                {
                new Conclusion(outVar, outVar.GetTerm(outTerm))
                });
        }

        private static void Main()
        {
            var db = KnowledgeBaseManager.GetInstance();
            var speedErrorVar = db.AddInputVariable("speed");
            var speedDotVar = db.AddInputVariable("speedDot");
            var controlVar = db.AddOutputVariable("control");

            speedErrorVar.AddTerm("negative", new LinearFunction(-20, -2, false));
            speedErrorVar.AddTerm("zero", new TriangularFunction(-15, 0, 15));
            speedErrorVar.AddTerm("positive", new LinearFunction(2, 20, true));

            speedDotVar.AddTerm("negative", new LinearFunction(-5, 0, false));
            speedDotVar.AddTerm("zero", new TriangularFunction(-4, 0, 4));
            speedDotVar.AddTerm("positive", new LinearFunction(0, 5, true));

            controlVar.AddTerm("very negative", new LinearFunction(-15, -8, false));
            controlVar.AddTerm("negative", new TriangularFunction(-10, -5, 0));
            controlVar.AddTerm("zero", new TriangularFunction(-3, 0, 3));
            controlVar.AddTerm("positive", new TriangularFunction(0, 5, 10));
            controlVar.AddTerm("very positive", new LinearFunction(8, 15, true));

            var rules = new List<Rule>
        {
            CreateRule(speedErrorVar, "negative", new MinOperation(), speedDotVar, "negative", controlVar, "very positive"),
            CreateRule(speedErrorVar, "negative", new MinOperation(), speedDotVar, "zero", controlVar, "positive"),
            CreateRule(speedErrorVar, "negative", new MinOperation(), speedDotVar, "positive", controlVar, "zero"),
            CreateRule(speedErrorVar, "zero", new MinOperation(), speedDotVar, "negative", controlVar, "positive"),
            CreateRule(speedErrorVar, "zero", new MinOperation(), speedDotVar, "zero", controlVar, "zero"),
            CreateRule(speedErrorVar, "zero", new MinOperation(), speedDotVar, "positive", controlVar, "negative"),
            CreateRule(speedErrorVar, "positive", new MinOperation(), speedDotVar, "negative", controlVar, "zero"),
            CreateRule(speedErrorVar, "positive", new MinOperation(), speedDotVar, "zero", controlVar, "negative"),
            CreateRule(speedErrorVar, "positive", new MinOperation(), speedDotVar, "positive", controlVar, "very negative")
        };

            var inputValues = new Dictionary<Variable, double>();
            var fa = new FuzzyAlgorithm.FuzzyAlgorithm();
            while (true)
            {
                Console.Write("Input speed error and dot: ");
                var strs = Console.ReadLine().Trim().Split();
                inputValues[speedErrorVar] = double.Parse(strs[0], CultureInfo.InvariantCulture);
                inputValues[speedDotVar] = double.Parse(strs[1], CultureInfo.InvariantCulture);
                var outputValues = fa.Execute(inputValues, rules);
                Console.WriteLine($"Control =  {outputValues[controlVar]}");
            }

        }
    }
}
