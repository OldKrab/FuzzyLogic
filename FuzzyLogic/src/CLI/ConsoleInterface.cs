using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.CLI.Commands;
using FuzzyLogic.Exceptions;

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
                    ExecuteCommand(command, parameters);
                }
                catch (InvalidOperationException e) 
                {
                    Console.WriteLine(@"Ошибка! " + e.Message);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("\nОперация прервана.");
                }
                catch (ConsoleExitException)
                {
                    return;
                }
            }
        }

        public void AddCommand(ConsoleCommand command)
        {
            _commands.Add(command.GetName(), command);
        }
        
        public List<string> GetCommandsNames() => _commands.Values.Select(c => c.GetName()).ToList();

        private void ExecuteCommand(string command, Dictionary<string, string> parameters)
        {
            if (command == "")
                return;
            if (command.Equals(_exitCommand, StringComparison.OrdinalIgnoreCase))
                throw new ConsoleExitException();
            if (!_commands.ContainsKey(command))
                throw new InvalidOperationException($"Неизвестная команда {command}!");
            _commands[command].Execute(parameters);
        }

        private string WaitForCommand(out Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Console.WriteLine();
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
                    : new[] { element })
                .SelectMany(element => element).ToArray();
        }

        private string ReadCommandLine()
        {
            Console.Write(WelcomeString);
            TabAutocomplete autocomplete = new TabAutocomplete(GetCommandsNames());
            MyConsole console = new MyConsole();

            console.AddKeyHandler(ConsoleKey.Tab, () =>
            {
                var matchingCommands = autocomplete.GetMatchingCommands(console.GetCurrentLine());
                if (matchingCommands.Count == 1)
                {
                    console.SetCurrentLine(matchingCommands[0]);
                    Console.Write('\r' + WelcomeString + console.GetCurrentLine());
                }
                else if (matchingCommands.Count > 1)
                {
                    Console.WriteLine();
                    matchingCommands.Sort();
                    foreach (var command in matchingCommands)
                        Console.WriteLine(@$"{command}");
                    Console.Write(WelcomeString + console.GetCurrentLine());
                }
            });

            var curCommandFromHistory = _commandHistory.Count;
            console.AddKeyHandler(ConsoleKey.UpArrow, () =>
            {
                if (curCommandFromHistory > 0)
                {
                    console.SetCurrentLine(_commandHistory[curCommandFromHistory - 1]);
                    curCommandFromHistory--;
                }
                console.RefreshLine();
            });

            console.AddKeyHandler(ConsoleKey.DownArrow, () =>
            {
                if (curCommandFromHistory <= _commandHistory.Count - 1)
                {
                    console.SetCurrentLine(curCommandFromHistory == _commandHistory.Count - 1
                        ? ""
                        : _commandHistory[curCommandFromHistory + 1]);
                    curCommandFromHistory++;
                }
                console.RefreshLine();
            });

            string command = console.ReadLine();
            _commandHistory.Add(command);
            return command;
        }

        private readonly Dictionary<string, ConsoleCommand> _commands = new(StringComparer.InvariantCultureIgnoreCase);
        private readonly List<string> _commandHistory = new();
        private string _welcomeString = "> ";
        private string WelcomeString => FuzzySystem.GetInstance().KnowledgeBase.Name + _welcomeString;
        private string _exitCommand = "exit";
    }
}