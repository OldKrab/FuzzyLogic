using System;
using System.Collections.Generic;
using FuzzyLogic.Algorithm;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic
{
    class Program
    {
   
        private static void Main()
        {
            FuzzyAlgorithm algorithm = new MamdaniAlgorithm();
            Console.WriteLine("Execute Mamdani Algorithm");
            algorithm.Execute(new Dictionary<Variable, double>(), new List<Rule>());
             algorithm = new SugenoAlgorithm();
            Console.WriteLine("\nExecute Sugeno Algorithm");
            algorithm.Execute(new Dictionary<Variable, double>(), new List<Rule>());
        }
    }
}
