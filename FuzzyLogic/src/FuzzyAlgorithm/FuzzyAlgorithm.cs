using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.FuzzyAlgorithm
{
    class FuzzyAlgorithm
    {
        public FuzzyAlgorithm()
        {
            ActivationOperation = new MinOperation();
            CombinationOperation = new MaxOperation();
            FuzzifierObj = new Fuzzifier();
            ActivatorObj = new Activator();
            CombinerObj = new Combiner();
            DefuzzifierObj = new Defuzzifier();
        }
        public Dictionary<Variable, double> Execute(Dictionary<Variable, double> inputValues, List<Rule> rules)
        {
            var fuzzifiedValues = FuzzifierObj.Fuzzify(inputValues, rules);
            var activatedFunctions = ActivatorObj.Activate(fuzzifiedValues, ActivationOperation);
            var combinedFunctions = CombinerObj.Combine(activatedFunctions, CombinationOperation);
            return DefuzzifierObj.Defuzzify(combinedFunctions);
        }
        public IOperation ActivationOperation { get; set; }
        public IOperation CombinationOperation { get; set; }
        public Fuzzifier FuzzifierObj { get; set; }
        public Activator ActivatorObj { get; set; }
        public Combiner CombinerObj { get; set; }
        public Defuzzifier DefuzzifierObj { get; set; }
    }
}