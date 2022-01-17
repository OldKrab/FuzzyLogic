using System.Collections.Generic;
using FuzzyLogic.CLI;
using FuzzyLogic.CLI.Commands;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            //var db = KnowledgeBaseManager.GetInstance();
            //db.AddInputVariable("speed");
            //db.AddTermToVariable("speed", "slow", new LinearFunction(0, 30, false));
            //db.AddTermToVariable("speed", "medium", new TriangularFunction(20, 30, 40));
            //db.AddTermToVariable("speed", "fast", new LinearFunction(30, 60, true));

            //db.AddOutputVariable("control");
            //db.AddTermToVariable("control", "negative", new LinearFunction(-6, -1, false));
            //db.AddTermToVariable("control", "zero", new TriangularFunction(-3, 0, 3));
            //db.AddTermToVariable("control", "positive", new LinearFunction(1, 6, true));

            //RuleParser parser = new RuleParser();
            //parser.OperationFactory = new MaxMinOperationFactory();
            //var builder = new RuleBuilder();
            //parser.Parse(builder, "IF speed fast THEN control negative");
            //db.AddRule(builder.GetResult());
            //parser.Parse(builder.Clear(), "IF speed medium THEN control zero");
            //db.AddRule(builder.GetResult());
            //parser.Parse(builder.Clear(), "IF speed slow and (speed fast and speed slow) THEN control positive");
            //db.AddRule(builder.GetResult());

            //string file = "KnowledgeBaseFiles/test.kb";
            //XmlExportVisitor export = new XmlExportVisitor();
            //export.Visit(db);
            //File.WriteAllText(file, export.Xml);
            new LoadKnowledgeBaseConsoleCommand().Execute(new Dictionary<string, string>{{"-file","files/test2.kb"}});
            var consoleInterface = new ConsoleInterface();
            consoleInterface.AddCommandHandler(new AddVariableConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermTrapezoidConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermTriangularConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermLinearConsoleCommand());
            consoleInterface.AddCommandHandler(new AddRuleConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveVariableConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveTermConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveRuleConsoleCommand());
            consoleInterface.AddCommandHandler(new GetVariablesConsoleCommand());
            consoleInterface.AddCommandHandler(new GetTermsConsoleCommand());
            consoleInterface.AddCommandHandler(new GetRulesConsoleCommand());
            consoleInterface.AddCommandHandler(new RunAlgorithmConsoleCommand());
            consoleInterface.AddCommandHandler(new LoadKnowledgeBaseConsoleCommand());
            consoleInterface.AddCommandHandler(new SaveKnowledgeBaseConsoleCommand());

            

            consoleInterface.Run();
        }
    }
}
