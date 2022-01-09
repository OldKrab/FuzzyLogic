using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
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
           var db = KnowledgeBaseManager.GetInstance();
           var printer = new ConsoleRuleExportVisitor();
           foreach (var rule in db.Rules)
           {
               printer.Visit(rule);
               Console.WriteLine(printer.Text);
           }
        }

        protected override List<ConsoleCommandParam> CreateParams()
        {
            return new List<ConsoleCommandParam>();
        }
    }
}