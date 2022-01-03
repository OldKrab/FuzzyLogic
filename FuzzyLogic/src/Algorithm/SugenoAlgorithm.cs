using FuzzyLogic.RuleParser;

namespace FuzzyLogic.Algorithm
{
     class SugenoAlgorithm:FuzzyAlgorithm
    {
        protected override void Fuzzify()
        {
            throw new System.NotImplementedException();
        }

        protected override void Activate()
        {
            throw new System.NotImplementedException();
        }

        protected override void Combine()
        {
            throw new System.NotImplementedException();
        }

        protected override void Defuzzify()
        {
            throw new System.NotImplementedException();
        }

        public override IRuleParser CreateRuleParser()
        {
            return new SugenoRuleParser();
        }
    }
}