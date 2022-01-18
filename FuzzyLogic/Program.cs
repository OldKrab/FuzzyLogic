using System.Collections.Generic;
using FuzzyLogic.CLI;
using FuzzyLogic.CLI.Commands;

namespace FuzzyLogic
{
    class Program
    {
        private static void Main()
        {
            var consoleInterface = new ConsoleInterface();
            consoleInterface.AddCommand(new AddVariableConsoleCommand());
            consoleInterface.AddCommand(new AddTermTrapezoidConsoleCommand());
            consoleInterface.AddCommand(new AddTermTriangularConsoleCommand());
            consoleInterface.AddCommand(new AddTermLinearConsoleCommand());
            consoleInterface.AddCommand(new AddRuleConsoleCommand());
            consoleInterface.AddCommand(new RemoveVariableConsoleCommand());
            consoleInterface.AddCommand(new RemoveTermConsoleCommand());
            consoleInterface.AddCommand(new RemoveRuleConsoleCommand());
            consoleInterface.AddCommand(new GetVariablesConsoleCommand());
            consoleInterface.AddCommand(new GetTermsConsoleCommand());
            consoleInterface.AddCommand(new GetRulesConsoleCommand());
            consoleInterface.AddCommand(new RunAlgorithmConsoleCommand());
            consoleInterface.AddCommand(new LoadKnowledgeBaseConsoleCommand());
            consoleInterface.AddCommand(new SaveKnowledgeBaseConsoleCommand());
            consoleInterface.AddCommand(new NewKnowledgeBaseConsoleCommand());
            consoleInterface.AddCommand(new RenameKnowledgeBaseConsoleCommand());

            
            consoleInterface.Run();
        }
    }
}
