using System;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.RuleBuilder;
using FuzzyLogic.KnowledgeBase.Visitor;

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

            RuleBuilder ruleBuilder = new RuleBuilder();

            RuleParser ruleParser = new RuleParser(db);
            ruleParser.Parse(ruleBuilder, "IF ( speed slow ) AND speed fast OR ( speed medium ) THEN speed fast");

            var rule = ruleBuilder.GetResult();
            XmlExportVisitor visitor = new XmlExportVisitor();
            visitor.Parse(rule);
            Console.WriteLine(visitor.Xml);
        }
    }
}
