using System.Collections.Generic;
using System.IO;
using FuzzyLogic.KnowledgeBase.Reader;

namespace FuzzyLogic.CLI.Commands
{
    public class LoadKnowledgeBaseConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "LoadKnowledgeBase";
        }

        public override string GetDescription()
        {
            return "Загружает базу знаний из файла";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var reader = new KnowledgeBaseXmlReader();
            FuzzySystem.GetInstance().KnowledgeBase = reader.Read(parameters[_fileParam]);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = new List<ConsoleCommandParam>();

            var param = new ConsoleCommandParam
            {
                Name = _fileParam,
                AskForInput = "Введите имя файла",
                Description = "Имя файла, где хранится база знаний"
            };
            param.AddValidator(File.Exists, "Файла с таким именем не существует!");
            parameters.Add(param);
            return parameters;
        }

        private const string _fileParam = "-file";
    }
}