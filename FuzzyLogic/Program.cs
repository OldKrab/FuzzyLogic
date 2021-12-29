using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            var db = KnowledgeBaseManager.GetInstance();
            var speed = db.AddInputVariable("speed");

            speed.AddTerm("slow", new LinearFunction(10, 30, false));
            speed.AddTerm("medium", new TriangularFunction(20, 30, 40));
            speed.AddTerm("fast", new LinearFunction(40, 60, true));

            var condition = new ConditionList();
            condition.AddCondition(new SingleCondition(speed, speed.GetTerm("slow")), new MinOperation());
            var subCond = new ConditionList();
            subCond.AddCondition(new SingleCondition(speed, speed.GetTerm("fast")), new SumOperation());
            subCond.AddCondition(new SingleCondition(speed, speed.GetTerm("medium")));
            condition.AddCondition(subCond);
            var conclusions = new List<Statement>{new Statement(speed, speed.GetTerm("slow"))};
            db.Rules.Add(new Rule(condition, conclusions));

            var xmlExporter = new XmlExportVisitor();
            xmlExporter.Parse(db);
            Console.WriteLine(xmlExporter.Xml);
        }
    }
}
