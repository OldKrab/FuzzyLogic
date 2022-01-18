using System.Collections.Generic;
using System.IO;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Readers;

namespace FuzzyLogic.CLI.Commands
{
    public class NewKnowledgeBaseConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "NewKnowledgeBase";
        }

        public override string GetDescription()
        {
            return "Создает новую базу знаний";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            FuzzySystem.GetInstance().KnowledgeBase = new KnowledgeBaseManager();
            FuzzySystem.GetInstance().KnowledgeBase.Name = parameters[_nameParam];
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();

            var param = new ConsoleCommandParam
            {
                Name = _nameParam,
                AskForInput = "Введите имя базы знаний",
                Description = "Имя базы знаний"
            };
            parameters.Add(param);
            return parameters;
        }

        private const string _nameParam = "-name";
    }
}