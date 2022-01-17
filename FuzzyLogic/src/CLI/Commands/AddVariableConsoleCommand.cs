using System.Collections.Generic;

namespace FuzzyLogic.CLI.Commands
{
    public class AddVariableConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return @"AddVariable";
        }

        public override string GetDescription()
        {
            return "Добавляет новую переменную";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            bool isInput = parameters[_typeParam] == "input";
            FuzzySystem.GetInstance().KnowledgeBase.AddVariable(parameters[_nameParam], isInput);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            List<ConsoleCommandParam> parameters = new List<ConsoleCommandParam>();
           
            var name = new ConsoleCommandParam
            {
                Name = _nameParam, 
                AskForInput = "Введите имя переменной",
                Description = "Имя переменной"
            };
            name.AddValidator(s => s != "", "Имя переменной пустое!");
            name.AddValidator(s => FuzzySystem.GetInstance().KnowledgeBase.TryGetVariable(s) == null,
                "Переменная уже существует!");
            parameters.Add(name);
           
            var type = new ConsoleCommandParam
            {
                Name = _typeParam, 
                AskForInput = "Введите тип переменной (input, output)", 
                Description = "Тип переменной. Допустимые значения: input, output"
            };
            type.AddValidator( s => s.ToLower() == "input" || s.ToLower() == "output", "Ожидалось input или output!");
            parameters.Add(type);

            return parameters;
        }

        private string _nameParam = "-name";
        private string _typeParam = "-type";
    }
}