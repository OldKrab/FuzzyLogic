using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.RuleParser;

namespace FuzzyLogic.Algorithm
{
    abstract class FuzzyAlgorithm
    {
        protected FuzzyAlgorithm()
        {
            ActivationOperation = new MinOperation();
            CombinationOperation = new MaxOperation();
        }

        public Dictionary<Variable, double> Execute(Dictionary<Variable, double> inputValues, List<Rule> rules)
        {
            InputValues = inputValues;
            Rules = rules;
            Fuzzify();
            Activate();
            Combine();
            Defuzzify();
            return OutputValues;
        }

        protected abstract void Fuzzify();
        protected abstract void Activate();
        protected abstract void Combine();
        protected abstract void Defuzzify();
        public abstract IRuleParser CreateRuleParser();

        protected Dictionary<Variable, double> InputValues;
        protected List<Rule> Rules;
        protected Dictionary<Variable, double> OutputValues;

        public IOperation ActivationOperation { get; set; }
        public IOperation CombinationOperation { get; set; }
    }
}