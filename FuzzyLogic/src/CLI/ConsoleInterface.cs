using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.CLI.Commands;

namespace FuzzyLogic.CLI
{

    public class ConsoleInterface
    {
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
                catch (OperationCanceledException)
                {
                    Console.WriteLine("\nОперация прервана.");
                }
            }
        }

        public void AddCommandHandler(ConsoleCommand command)
        {
            _commands.Add(command.GetName(), command);
        }

        private string WaitForCommand(out Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            var line = ReadCommandLine();

            var words = SplitWithQuotas(line);

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

        private static string[] SplitWithQuotas(string line)
        {
            return line.Split('"')
                .Select((element, index) => index % 2 == 0  
                    ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) 
                    : new string[] { element }) 
                .SelectMany(element => element).ToArray();
        }

        private string ReadCommandLine()
        {
            Console.Write(_welcomeString);
            TabAutocomplete autocomplete = new TabAutocomplete(GetCommandsNames());
            MyConsole console = new MyConsole();

            console.AddKeyHandler(ConsoleKey.Tab, () =>
            {
                var matchingCommands = autocomplete.GetMatchingCommands(console.GetCurrentLine());
                if (matchingCommands.Count == 1)
                {
                    console.SetCurrentLine(matchingCommands[0]);
                    Console.Write('\r' + _welcomeString + console.GetCurrentLine());
                }
                else if (matchingCommands.Count > 1)
                {
                    Console.WriteLine();
                    matchingCommands.Sort();
                    foreach (var command in matchingCommands)
                        Console.WriteLine(@$"{command}");
                    Console.Write(_welcomeString + console.GetCurrentLine());
                }
            });

            var curCommandFromHistory = _commandHistory.Count - 1;
            if (curCommandFromHistory >= 0)
            {
                console.AddKeyHandler(ConsoleKey.UpArrow, () =>
                {
                    console.SetCurrentLine(_commandHistory[curCommandFromHistory]);
                    if (curCommandFromHistory > 0) curCommandFromHistory--;
                    Console.Write('\r' + _welcomeString + console.GetCurrentLine());
                });

                console.AddKeyHandler(ConsoleKey.DownArrow, () =>
                {
                    console.SetCurrentLine(_commandHistory[curCommandFromHistory]);
                    if (curCommandFromHistory < _commandHistory.Count - 1) curCommandFromHistory++;
                    Console.Write('\r' + _welcomeString + console.GetCurrentLine());
                });
            }

            string command = console.ReadLine();
            _commandHistory.Add(command);
            return command;
        }

        public List<ConsoleCommand> GetCommands() => _commands.Values.ToList();
        public List<string> GetCommandsNames() => _commands.Values.Select(c => c.GetName()).ToList();

        private Dictionary<string, ConsoleCommand> _commands = new Dictionary<string, ConsoleCommand>(StringComparer.InvariantCultureIgnoreCase);
        private List<string> _commandHistory = new List<string>();
        private string _welcomeString = "> ";
        private string _exitCommand = "exit";
    }
}