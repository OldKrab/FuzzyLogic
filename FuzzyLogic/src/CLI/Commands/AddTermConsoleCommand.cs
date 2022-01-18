using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.CLI.Commands
{
    public abstract class AddTermConsoleCommand:ConsoleCommand
    {
        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var varName = parameters[VarNameParam];
            var termName = parameters[TermNameParam];
            var function = GetMembershipFunction(parameters);

            FuzzySystem.GetInstance().KnowledgeBase.AddTermToVariable(varName, termName, function);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();
            var varName = new ConsoleCommandParam
            {
                Name = VarNameParam,
                AskForInput = "Введите имя переменной",
                Description = "Имя переменной, к которой добавляется терм"
            };
            varName.AddValidator(s => s != "", "Имя переменной пустое!");
            varName.AddValidator(s => FuzzySystem.GetInstance().KnowledgeBase.TryGetVariable(s) != null,
                "Переменной не существует!");
            parameters.Add(varName);

            var termName = new ConsoleCommandParam
            {
                Name = TermNameParam,
                AskForInput = "Введите имя добавляемого терма",
                Description = "Имя добавляемого терма"
            };
            termName.AddValidator(s => s != "", "Имя терма пустое!");
            parameters.Add(termName);

            return parameters;
        }

        protected abstract IMembershipFunction GetMembershipFunction(Dictionary<string, string> parameters);

        protected string VarNameParam = "-varname";
        protected string TermNameParam = "-termname";
    }
}