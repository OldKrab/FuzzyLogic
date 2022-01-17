using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.CLI.Commands
{
    public class RemoveRuleConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "RemoveRule";
        }

        public override string GetDescription()
        {
            return "Удаляет указанное правило";
        }

        protected override void CheckRequirementsBeforeExecute()
        {
            KnowledgeBaseManager db = FuzzySystem.GetInstance().KnowledgeBase;
            if (db.Rules.Count == 0)
                throw new InvalidOperationException("Нет правил.");
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            var rules = FuzzySystem.GetInstance().KnowledgeBase.Rules;
            rules.RemoveAt(int.Parse(parameters[_indexParam]) - 1);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {

            List<ConsoleCommandParam> parameters = new List<ConsoleCommandParam>();

            var sb = new StringBuilder("Текущие правила:\n");
            var rules = FuzzySystem.GetInstance().KnowledgeBase.Rules;
            var printer = new ConsoleRuleExportVisitor();
            foreach (var (rule, i) in rules.Select((x, i) => (x, i)))
            {
                printer.Visit(rule);
                sb.AppendLine($"{i + 1}) {printer.Text}");
                printer.Clear();
            }
            sb.Append("Введите номер удаляемого правила");
            var index = new ConsoleCommandParam
            {
                Name = _indexParam,
                AskForInput = sb.ToString(),
                Description = "Номер удаляемого правила"
            };
            index.AddValidator(s => double.TryParse(s, out _), "Номер не число!");
            index.AddValidator(s => double.Parse(s) > 0, "Номер меньше 1!");
            index.AddValidator(s => double.Parse(s) <= rules.Count, $"Номер больше {rules.Count}!");
            parameters.Add(index);

            return parameters;
        }

        private const string _indexParam = "-index";
    }
}