using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.CLI.Commands
{
    public class RemoveVariableConsoleCommand:ConsoleCommand
    {
        public override string GetName()
        {
            return "RemoveVariable";
        }

        public override string GetDescription()
        {
            return "Удаляет переменную с заданным именем";
        }

        protected override void CheckRequirementsBeforeExecute()
        {
            KnowledgeBaseManager db = FuzzySystem.GetInstance().KnowledgeBase;
            if (db.Variables.Count == 0)
                throw new InvalidOperationException("Нет переменных.");
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            FuzzySystem.GetInstance().KnowledgeBase.RemoveVariable(parameters[_nameParam]);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            List<ConsoleCommandParam> parameters = new List<ConsoleCommandParam>();
           
            var name = new ConsoleCommandParam
            {
                Name = _nameParam, 
                AskForInput = "Введите имя удаляемой переменной",
                Description = "Имя удаляемой переменной"
            };
            name.AddValidator(s => s != "", "Имя переменной пустое!");
            parameters.Add(name);
           
            return parameters;
        }

        private string _nameParam = "-name";
    }
}