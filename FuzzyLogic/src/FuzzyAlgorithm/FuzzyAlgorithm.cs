using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.FuzzyAlgorithm
{
    class FuzzyAlgorithm
    {
        public Dictionary<Variable, double> Execute(Dictionary<Variable, double> inputValues, List<Rule> rules)
        {
            return Defuzzifier.Defuzzify(
                Combiner.Combine(
                    Activator.Activate(
                        Fuzzifier.Fuzzify(inputValues, rules))));
        }

        public Fuzzifier Fuzzifier { get; set; }
        public FuzzyActivator Activator { get; set; }
        public FuzzyCombiner Combiner { get; set; }
        public Defuzzifier Defuzzifier { get; set; }
    }
}