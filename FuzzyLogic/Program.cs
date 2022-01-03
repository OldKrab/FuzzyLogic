using System;
using FuzzyLogic.Algorithm;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;
using FuzzyLogic.KnowledgeBase.Visitor;
using FuzzyLogic.RuleParser;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            var db = KnowledgeBaseManager.GetInstance();
            db.AddInputVariable("speed");
            db.AddTermToVariable("speed", "slow", new LinearFunction(10, 30, false));
            db.AddTermToVariable("speed", "medium", new TriangularFunction(20, 30, 40));
            db.AddTermToVariable("speed", "fast", new LinearFunction(40, 60, true));

            string ruleString = "IF ( speed slow ) AND speed fast OR ( speed medium ) THEN speed fast";

            FuzzyAlgorithm algorithm = new MamdaniAlgorithm();
            RuleBuilder ruleBuilder = new RuleBuilder();
            IRuleParser ruleParser = algorithm.CreateRuleParser();
            ruleParser.Parse(ruleBuilder, ruleString);

            algorithm = new SugenoAlgorithm();
            ruleBuilder.Clear();
            ruleParser = algorithm.CreateRuleParser();
            ruleParser.Parse(ruleBuilder, ruleString);

        }
    }
}
