using System;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilders;

namespace FuzzyLogic.KnowledgeBase.RuleParsers
{
    class RuleParser : IRuleParser
    {
        public RuleParser()
        {
            _db = FuzzySystem.GetInstance().KnowledgeBase;
            OperationFactory = new MaxMinOperationFactory();
        }

        public void Parse(IRuleBuilder builder, string rule)
        {
            var words = SplitRule(rule);
            if (words[0].ToLower() != "if")
                throw new InvalidOperationException("В начале ожидалось IF!");
            int i = 1;
            while (i < words.Length && words[i].ToLower() != "then")
            {
                if (words[i] == "(")
                    builder.StartConditionList();
                else if (words[i] == ")")
                    builder.EndConditionList();
                else if (words[i].ToLower() == "and")
                    builder.AddOperation(OperationFactory.CreateAndOperation());
                else if (words[i].ToLower() == "or")
                    builder.AddOperation(OperationFactory.CreateOrOperation());
                else
                {
                    var var = _db.GetVariable(words[i++]);
                    var term = var.GetTerm(i == words.Length ? "" : words[i]);
                    builder.AddCondition(var, term);
                }
                i++;
            }
            if (i == words.Length || words[i].ToLower() != "then")
                throw new InvalidOperationException("Отсутствует THEN!");
            i++;
            while (i < words.Length)
            {
                Variable var = _db.GetVariable(words[i++]);
                Term term = var.GetTerm(words[i++]);
                builder.AddConclusion(var, term);
            }
        }

        public IOperationFactory OperationFactory { get; set; }


        private string[] SplitRule(string rule)
        {
            var words = rule.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words
                .Select(word => word.Split('('))
                .SelectMany(splitWords => splitWords.Select(w => w == "" ? "(" : w))
                .Select(word => word.Split(')'))
                .SelectMany(splitWords => splitWords.Select(w => w == "" ? ")" : w))
                .ToArray();
        }

        private readonly KnowledgeBaseManager _db;
    }

}