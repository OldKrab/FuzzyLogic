using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.MembershipFunctions.Integrator;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.FuzzyAlgorithm
{
    class Defuzzifier
    {
        public Dictionary<Variable, double> Defuzzify(Dictionary<Variable, IFunction> combinedValues)
        {
            var outputValues = new Dictionary<Variable, double>();
            foreach (var it in combinedValues)
            {
                var variable = it.Key;
                var function = it.Value;

                var numeratorFunc = new CombinedFunction(new ProdOperation(),
                    new List<IFunction> { function, new Function(x => x, function.GetMinValue(), function.GetMaxValue()) });
                var integrator = new RombergIntegrator();
                var numerator = integrator.Integrate(numeratorFunc, numeratorFunc.GetMinValue(), numeratorFunc.GetMaxValue());
                var denominator = integrator.Integrate(function, function.GetMinValue(), function.GetMaxValue());
                outputValues.Add(variable, numerator / denominator);
            }

            return outputValues;
        }
    }
}