using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.CLI.Commands
{
    public class GetRulesConsoleCommand:ConsoleCommand
    {
        public override string GetName()
        {
            return "GetRules";
        }

        public override string GetDescription()
        {
            return "Выводит список всех правил";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
           var printer = new ConsoleRuleExportVisitor();
           var rules = FuzzySystem.GetInstance().KnowledgeBase.Rules;
           if (rules.Count == 0)
           {
               Console.WriteLine("Нет правил.");
               return;
           }
           foreach (var (rule, i) in rules.Select((r, i) => (r,i)))
           {
               printer.Visit(rule);
               Console.WriteLine($"{i+1}) {printer.Text}");
               printer.Clear();
           }
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            return new List<ConsoleCommandParam>();
        }
    }
}