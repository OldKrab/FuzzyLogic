using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.CLI.Commands;

namespace FuzzyLogic.CLI
{

    public class ConsoleInterface
    {
        public ConsoleInterface()
        {
            AddCommandHandler(new HelpCommand(this));
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = WaitForCommand(out var parameters);
                    if (command == "")
                        continue;
                    if (command.Equals(_exitCommand, StringComparison.OrdinalIgnoreCase))
                        return;

                    if (!_commands.ContainsKey(command))
                        throw new InvalidOperationException($"Неизвестная команда {command}!");

                    _commands[command].Execute(parameters);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(@"Ошибка! " + e.Message);
                }
            }
        }

        public void AddCommandHandler(ConsoleCommand command)
        {
            _commands.Add(command.GetName(), command);
        }

        public string WaitForCommand(out Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Console.Write(_welcomeString);
            var line = Console.ReadLine() ?? "";
            var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0) return "";

            var command = words[0];
            for (int i = 1; i < words.Length; i += 2)
            {
                var param = words[i];
                var value = i + 1 == words.Length ? "" : words[i + 1];
                if (parameters.ContainsKey(param))
                    throw new InvalidOperationException($"Параметр {param} определен более одного раза!");
                parameters.Add(param, value);
            }
            return command;
        }

        public List<ConsoleCommand> GetCommands() => _commands.Values.ToList();

        private Dictionary<string, ConsoleCommand> _commands = new Dictionary<string, ConsoleCommand>(StringComparer.InvariantCultureIgnoreCase);
        private string _welcomeString = "> ";
        private string _exitCommand = "exit";
    }
}