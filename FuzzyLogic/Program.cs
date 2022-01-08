using System;
using FuzzyLogic.CLI;
using FuzzyLogic.CLI.Commands;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Builder;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

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
            consoleInterface.AddCommandHandler(new AddTrapezoidTermConsoleCommand());
            consoleInterface.AddCommandHandler(new AddTriangularTermConsoleCommand());
            consoleInterface.AddCommandHandler(new AddLinearTermConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveVariableConsoleCommand());
            consoleInterface.AddCommandHandler(new RemoveTermConsoleCommand());
            consoleInterface.Run();
        }
    }
}
