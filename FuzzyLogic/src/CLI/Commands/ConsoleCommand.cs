using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.CLI.Commands
{
    public abstract class ConsoleCommand
    {
        public void Execute(Dictionary<string, string> parameters)
        {
            if (CheckForHelpParams(parameters))
            {
                WriteHelp();
                return;
            }

            CheckForUnknownEnteredParams(parameters);
            CheckForNotEnteredParams(parameters);
            CheckForValidParams(parameters);
            AdditionallyCheckParams();

            ExecuteWithValidParams(parameters);
        }

        public abstract string GetName();
        public abstract string GetDescription();


        protected virtual void AdditionallyCheckParams() { }

        protected abstract void ExecuteWithValidParams(Dictionary<string, string> parameters);

        protected abstract List<ConsoleCommandParam> GetParams();

        private bool CheckForHelpParams(Dictionary<string, string> parameters)
        {
            return parameters.ContainsKey(_helpParam) && parameters.Count == 1;
        }

        private void WriteHelp()
        {
            Console.WriteLine(@$"Команда {GetName()}");
            Console.WriteLine(@"Описание:");
            Console.WriteLine($@"{GetDescription()}");
            Console.WriteLine(@"Параметры:");
            var parameters = GetParams();
            if (parameters.Count == 0)
                Console.WriteLine("Нет параметров.");
            else
                foreach (var param in parameters)
                    Console.WriteLine(@$"[{param.Name}] - {param.Description}");
        }

        private void CheckForNotEnteredParams(Dictionary<string, string> parameters)
        {
            var @params = GetParams();
            foreach (var param in @params.Where(param => !parameters.ContainsKey(param.Name.ToLower())))
            {
                Console.Write($@"[{param.Name}] {param.AskForInput}: ");

                MyConsole console = new MyConsole();
                console.AddKeyHandler(ConsoleKey.Escape, () => throw new OperationCanceledException());
                string value = console.ReadLine();

                parameters.Add(param.Name, value);
            }
        }

        private void CheckForValidParams(Dictionary<string, string> parameters)
        {
            var @params = GetParams();
            foreach (var param in @params)
                if (!param.IsValueValid(parameters[param.Name], out var errorMessage))
                    throw new InvalidOperationException(errorMessage);
        }

        private void CheckForUnknownEnteredParams(Dictionary<string, string> parameters)
        {
            var @params = GetParams();
            foreach (var enteredParam in parameters.Keys)
                if (!@params.Exists(p => p.Name.Equals(enteredParam, StringComparison.InvariantCultureIgnoreCase)))
                    throw new InvalidOperationException($"Неизвестный параметр {enteredParam}");
        }

        private string _helpParam = "-help";
    }
}