using System;
using System.Collections.Generic;
using FuzzyLogic.Algorithm;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Operations;

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
            FuzzyAlgorithm algorithm = FuzzySystem.GetInstance().FuzzyAlgorithm;
            algorithm.ActivationOperation =parameters[_activationOpParam].ToLower() switch
            {
                "m" => new MinOperation(),
                "p" => new ProdOperation()
            };
            algorithm.CombinationOperation =parameters[_combinationOpParam].ToLower() switch
            {
                "m" => new MaxOperation(),
                "s" => new SumOperation()
            };

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

            var activationOp = new ConsoleCommandParam
            {
                Name = _activationOpParam,
                AskForInput = "Выберите тип операции активации (min (M) или prod (P))",
                Description = "Тип операции активации (min (M) или prod (P))",
                DefaultValue = "M"
            };
            activationOp.AddValidator(s => s.ToLower() == "m" || s.ToLower() == "p", "Тип операций ожидался M или P!");
            parameters.Add(activationOp);

            var combinationOp = new ConsoleCommandParam
            {
                Name = _combinationOpParam,
                AskForInput = "Выберите тип операции комбинирования (max (M) или sum (S))",
                Description = "Тип операции комбинирования (max (M) или sum (S))",
                DefaultValue = "M"
            };
            combinationOp.AddValidator(s => s.ToLower() == "m" || s.ToLower() == "s", "Тип операций ожидался M или S!");
            parameters.Add(combinationOp);

            return parameters;
        }

        private const string _activationOpParam = "-activationOp";
        private const string _combinationOpParam = "-combinationOp";
    }
}