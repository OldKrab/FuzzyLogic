using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
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

            KnowledgeBaseManager db = KnowledgeBaseManager.GetInstance();
            db.AddTermToVariable(varName, termName, function);
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

        protected abstract IFunction GetMembershipFunction(Dictionary<string, string> parameters);

        protected string VarNameParam = "-varname";
        protected string TermNameParam = "-termname";
    }
}