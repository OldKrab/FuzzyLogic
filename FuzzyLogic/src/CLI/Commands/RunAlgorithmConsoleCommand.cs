using System;
using System.Collections.Generic;
using FuzzyLogic.Algorithm;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.CLI.Commands
{
    public class RunAlgorithmConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "RunAlgorithm";
        }

        public override string GetDescription()
        {
            return "Запускает нечеткий алгоритм";
        }

        protected override void CheckRequirementsBeforeExecute()
        {
            KnowledgeBaseManager db = FuzzySystem.GetInstance().KnowledgeBase;
            if (db.InputVariables.Count == 0)
                throw new InvalidOperationException("Нет входных переменных.");
            if (db.Rules.Count == 0)
                throw new InvalidOperationException("Нет правил.");
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            KnowledgeBaseManager db = FuzzySystem.GetInstance().KnowledgeBase;
            MamdaniAlgorithm algorithm = new MamdaniAlgorithm();
            Dictionary<Variable, double> inputValues = new Dictionary<Variable, double>();
            foreach (var inputVariable in db.InputVariables)
            {
                var paramName = "-" + inputVariable.Name;
                inputValues[inputVariable] = double.Parse(parameters[paramName]);
            }
            var outputValues = algorithm.Execute(inputValues, db.Rules);
            Console.WriteLine(@"Значения выходных переменных:");
            foreach (var (outputVar, value) in outputValues)
            {
                Console.WriteLine($"{outputVar.Name} = {value}");
            }
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();
            bool NumberValidator(string x) => double.TryParse(x, out _);
            var errorMsg = "Не число!";

            foreach (var inputVariable in FuzzySystem.GetInstance().KnowledgeBase.InputVariables)
            {
                var paramName = "-" + inputVariable.Name;
                var param = new ConsoleCommandParam
                {
                    Name = paramName,
                    AskForInput = $"Введите значение для переменной {inputVariable.Name}",
                    Description = $"Входное значение для переменной {inputVariable.Name}"
                };
                param.AddValidator(NumberValidator, errorMsg);
                parameters.Add(param);
            }

            return parameters;
        }
    }
}