using System;
using FuzzyLogic.CLI;
using FuzzyLogic.CLI.Commands;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            var db = KnowledgeBaseManager.GetInstance();
            var speed = db.AddInputVariable("speed");
            var speedSlow = db.AddTermToVariable("speed", "slow", new LinearFunction(10, 30, false));
            var speedMedium = db.AddTermToVariable("speed", "medium", new TriangularFunction(20, 30, 40));
            var speedFast = db.AddTermToVariable("speed", "fast", new LinearFunction(40, 60, true));

            var consoleInterface = new ConsoleInterface();
            consoleInterface.AddCommandHandler(new AddVariableConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermTrapezoidConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermTriangularConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTermLinearConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveVariableConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveTermConsoleCommand());
            consoleInterface.AddCommandHandler(new AddRuleConsoleCommand());
            consoleInterface.Run();
        }
    }
}
