using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleParsers;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.Algorithm
{
    class MamdaniAlgorithm : FuzzyAlgorithm
    {
        private IFunctionIntegrator Integrator { get; set; } = new RombergIntegrator();

        protected override void Fuzzify()
        {
            _fuzzifiedValues = Rules.Select(rule => new { rule, value = rule.Condition.Fuzzify(InputValues) })
                .ToDictionary(it => it.rule, it => it.value);
        }

        protected override void Activate()
        {
            _activatedFunctions = new Dictionary<Statement, IFunction>();
            foreach (var it in _fuzzifiedValues)
            {
                var rule = it.Key;
                var activatingValue = it.Value;
                foreach (var conclusion in rule.Conclusions)
                {
                    _activatedFunctions.Add(conclusion, new ActivatedFunction(conclusion.Term.Function,
                        ActivationOperation, activatingValue));
                }
            }
        }

        protected override void Combine()
        {
            var functions = new Dictionary<Variable, List<IFunction>>();
            foreach (var it in _activatedFunctions)
            {
                var conclusion = it.Key;
                var function = it.Value;
                if (!functions.ContainsKey(conclusion.Variable))
                    functions.Add(conclusion.Variable, new List<IFunction>());
                functions[conclusion.Variable].Add(function);
            }

            _combinedFunctions = new Dictionary<Variable, IFunction>();
            foreach (var it in functions)
                _combinedFunctions.Add(it.Key, new CombinedFunction(CombinationOperation, it.Value));
        }

        protected override void Defuzzify()
        {
            OutputValues = new Dictionary<Variable, double>();
            foreach (var it in _combinedFunctions)
            {
                var variable = it.Key;
                var function = it.Value;

                var numeratorFunc = new CombinedFunction(new ProdOperation(),
                    new List<IFunction> { function, new Function(x => x, variable.MinValue, variable.MinValue) });

                var numerator = Integrator.Integrate(numeratorFunc, variable.MinValue, variable.MaxValue);
                var denominator = Integrator.Integrate(function, variable.MinValue, variable.MaxValue);
                OutputValues.Add(variable, numerator / denominator);
            }
        }

        public override IRuleParser CreateRuleParser()
        {
            return new RuleParser();
        }

        private Dictionary<Rule, double> _fuzzifiedValues;
        private Dictionary<Statement, IFunction> _activatedFunctions;
        private Dictionary<Variable, IFunction> _combinedFunctions;
    }
}