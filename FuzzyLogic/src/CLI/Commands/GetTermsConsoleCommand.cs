using System;
using System.Collections.Generic;

namespace FuzzyLogic.CLI.Commands
{
    public class GetTermsConsoleCommand:ConsoleCommand
    {
        public override string GetName()
        {
            return "GetTerms";
        }

        public override string GetDescription()
        {
            return "Выводит список всех термов у заданной переменной";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var variable = FuzzySystem.GetInstance().KnowledgeBase.GetVariable(parameters[_varNameParam]);
            Console.WriteLine($"Список терм у переменной {variable.Name}:");
            foreach (var term in variable.Terms)
            {
                Console.WriteLine(term);
            }
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();
            var varName = new ConsoleCommandParam
            {
                Name = _varNameParam,
                AskForInput = "Введите имя переменной",
                Description = "Имя переменной, у которой нужно получить термы"
            };
            varName.AddValidator(s => s != "", "Имя переменной пустое!");
            parameters.Add(varName);

            return parameters;
        }

        private string _varNameParam = "-varName";
    }
}