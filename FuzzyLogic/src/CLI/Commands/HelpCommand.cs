using System;
using System.Collections.Generic;
using FuzzyLogic.CLI.Commands;

namespace FuzzyLogic.CLI
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand(ConsoleInterface cli)
        {
            _cli = cli;
        }
        public override string GetName()
        {
            return "-help";
        }

        public override string GetDescription()
        {
            return "Отображает список доступных команд";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var commands = _cli.GetCommands();
            Console.WriteLine(@"Список доступных команд:");
            foreach (var command in commands)
                if (command.GetName() != this.GetName())
                {
                    Console.WriteLine($"{command.GetName()}");
                }
        }

        protected override List<ConsoleCommandParam> CreateParams()
        {
            return new List<ConsoleCommandParam>();
        }

        private readonly ConsoleInterface _cli;
    }
}