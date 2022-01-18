using System.Collections.Generic;
using System.IO;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.CLI.Commands
{
    public class RenameKnowledgeBaseConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "RenameKnowledgeBase";
        }

        public override string GetDescription()
        {
            return "Изменяет имя текущей базы знаний";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            FuzzySystem.GetInstance().KnowledgeBase.Name = parameters[_nameParam];
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();

            var param = new ConsoleCommandParam
            {
                Name = _nameParam,
                AskForInput = "Введите новое имя базы знаний",
                Description = "Новое имя текущей базы знаний"
            };
            parameters.Add(param);

            return parameters;
        }

        private const string _nameParam = "-name";
    }
}