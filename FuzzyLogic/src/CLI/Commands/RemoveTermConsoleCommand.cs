using System.Collections.Generic;

namespace FuzzyLogic.CLI.Commands
{
    public class RemoveTermConsoleCommand:ConsoleCommand
    {
        public override string GetName()
        {
            return "RemoveTerm";
        }

        public override string GetDescription()
        {
            return "Удаляет указанный терм из переменной";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var varName = parameters[VarNameParam];
            var termName = parameters[TermNameParam];

            FuzzySystem.GetInstance().KnowledgeBase.RemoveTermFromVariable(varName, termName);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();
            var varName = new ConsoleCommandParam
            {
                Name = VarNameParam,
                AskForInput = "Введите имя переменной",
                Description = "Имя переменной, у которой удаляется терм"
            };
            varName.AddValidator(s => s != "", "Имя переменной пустое!");
            parameters.Add(varName);

            var termName = new ConsoleCommandParam
            {
                Name = TermNameParam,
                AskForInput = "Введите имя удаляемого терма",
                Description = "Имя удаляемого терма"
            };
            termName.AddValidator(s => s != "", "Имя терма пустое!");
            parameters.Add(termName);

            return parameters;
        }

        protected string VarNameParam = "-varname";
        protected string TermNameParam = "-termname";
    }
}