using System;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;
using FuzzyLogic.KnowledgeBase.Visitor;
using FuzzyLogic.RuleParsers;
using Microsoft.VisualBasic;

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

            var ruleString = "IF speed slow AND speed fast OR speed medium THEN speed fast";
            var ruleParser = new RuleParser();
            var ruleBuilder = new RuleBuilder();
            var ruleExporter = new XmlExportVisitor();

            ruleParser.OperationFactory = new MaxMinOperationFactory();
            ruleParser.Parse(ruleBuilder, ruleString);
            ruleExporter.Parse(ruleBuilder.GetResult());
            Console.WriteLine(ruleExporter.Xml);

            ruleExporter.Clear();
            ruleBuilder.Clear();
            ruleParser.OperationFactory = new SumProdOperationFactory();
            ruleParser.Parse(ruleBuilder, ruleString);
            ruleExporter.Parse(ruleBuilder.GetResult());
            Console.WriteLine(ruleExporter.Xml);
        }
    }
}
