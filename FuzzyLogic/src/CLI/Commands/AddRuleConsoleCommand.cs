using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;
using FuzzyLogic.RuleParsers;

namespace FuzzyLogic.CLI.Commands
{
    public class AddRuleConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "AddRule";
        }

        public override string GetDescription()
        {
            return "Добавляет новое правило";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            KnowledgeBaseManager db = KnowledgeBaseManager.GetInstance();
            RuleParser parser = new RuleParser();
            if (parameters[_operationsParam].ToLower() == "m")
                parser.OperationFactory = new MaxMinOperationFactory();
            else if (parameters[_operationsParam].ToLower() == "p")
                parser.OperationFactory = new SumProdOperationFactory();
            var builder = new RuleBuilder();
            parser.Parse(builder, parameters[_ruleParam]);
            db.AddRule(builder.GetResult());
        }

        protected override List<ConsoleCommandParam> CreateParams()
        {
            var parameters = new List<ConsoleCommandParam>();
            var varName = new ConsoleCommandParam
            {
                Name = _ruleParam,
                AskForInput = "Введите новое правило",
                Description = "Правило в формате IF (var1 term1 AND var1 term2) OR var1 term3 THEN var2 term4"
            };
            varName.AddValidator(s => s != "", "Правило пустое!");
            parameters.Add(varName);

            var operators = new ConsoleCommandParam
            {
                Name = _operationsParam,
                AskForInput = "Выберите тип операций AND и OR (min/max (M) или prod/sum (P))",
                Description = "Тип операций AND и OR (min/max (M) или prod/sum (P))"
            };
            operators.AddValidator(s => s.ToLower() == "m" || s.ToLower() == "p", "Тип операций ожидался M или P!");
            parameters.Add(operators);
            return parameters;
        }

        private string _ruleParam = "-rule";
        private string _operationsParam = "-operations";
    }
}