using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.CLI.Commands
{
    public abstract class ConsoleCommand
    {
        public void Execute(Dictionary<string, string> parameters)
        {
            CheckRequirementsBeforeExecute();
            if (CheckForHelpParam(parameters))
            {
                WriteHelp();
                return;
            }

            CheckForEnteredUnknownParams(parameters);
            CheckForNotEnteredParams(parameters);
            CheckParamsIsValid(parameters);

            ExecuteWithValidParams(parameters);
        }

        public abstract string GetName();
        public abstract string GetDescription();

        protected abstract void ExecuteWithValidParams(Dictionary<string, string> parameters);
        protected abstract List<ConsoleCommandParam> GetParams();

        protected virtual void CheckRequirementsBeforeExecute(){}

        private bool CheckForHelpParam(Dictionary<string, string> parameters)
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
                if (param.HasDefaultValue)
                {
                    parameters.Add(param.Name, param.DefaultValue);
                    continue;
                }

                Console.Write($@"[{param.Name}] {param.AskForInput}: ");

                MyConsole console = new MyConsole();
                console.AddKeyHandler(ConsoleKey.Escape, () => throw new OperationCanceledException());
                string value = console.ReadLine();

                CheckParamIsValid(param, value);
                parameters.Add(param.Name, value);
            }
        }

        private void CheckParamsIsValid(Dictionary<string, string> parameters)
        {
            var @params = GetParams();
            foreach (var param in @params)
                CheckParamIsValid(param, parameters[param.Name]);
        }

        private void CheckParamIsValid(ConsoleCommandParam param, string value)
        {
            if (!param.IsValueValid(value, out var errorMessage))
                throw new InvalidOperationException(errorMessage);
        }

        private void CheckForEnteredUnknownParams(Dictionary<string, string> parameters)
        {
            var @params = GetParams();
            foreach (var enteredParam in parameters.Keys)
                if (!@params.Exists(p => p.Name.Equals(enteredParam, StringComparison.InvariantCultureIgnoreCase)))
                    throw new InvalidOperationException($"Неизвестный параметр {enteredParam}");
        }

        private string _helpParam = "-help";
    }
}