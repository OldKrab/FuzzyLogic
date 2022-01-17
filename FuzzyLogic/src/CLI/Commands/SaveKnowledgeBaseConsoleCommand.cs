using System.Collections.Generic;
using System.IO;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.CLI.Commands
{
    public class SaveKnowledgeBaseConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "SaveKnowledgeBase";
        }

        public override string GetDescription()
        {
            return "Сохраняет базу знаний в файл";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            XmlExportVisitor exportVisitor = new XmlExportVisitor();
            exportVisitor.Visit(FuzzySystem.GetInstance().KnowledgeBase);
            File.WriteAllText(parameters[_fileParam], exportVisitor.Xml);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();

            var param = new ConsoleCommandParam
            {
                Name = _fileParam,
                AskForInput = "Введите имя файла",
                Description = "Имя файла, куда сохранится база знаний"
            };
            parameters.Add(param);
            return parameters;
        }

        private const string _fileParam = "-file";
    }
}