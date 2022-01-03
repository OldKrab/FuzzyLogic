using System;
using FuzzyLogic.KnowledgeBase;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;

namespace FuzzyLogic.RuleParser
{
    class MamdaniRuleParser:IRuleParser
    {
        public MamdaniRuleParser()
        {
            _db = KnowledgeBaseManager.GetInstance();
            OperationFactory = new MaxMinOperationFactory();
        }

        public void Parse(IRuleBuilder builder, string rule)
        {
            Console.WriteLine("Parsing use Mamdani RuleParser...");
            
            var words = rule.Split();
            int i = 1;
            while (i < words.Length && words[i] != "THEN")
            {
                if (words[i] == "(")
                    builder.StartConditionList();
                else if (words[i] == ")")
                    builder.EndConditionList();
                else if (words[i] == "AND")
                    builder.AddOperation(OperationFactory.CreateAndOperation());
                else if (words[i] == "OR")
                    builder.AddOperation(OperationFactory.CreateOrOperation());
                else
                {
                    Variable var = _db.GetVariable(words[i++]);
                    Term term = var.GetTerm(words[i]);
                    builder.AddCondition(var, term);
                }
                i++;
            }
            i++;
            while (i < words.Length)
            {
                Variable var = _db.GetVariable(words[i++]);
                Term term = var.GetTerm(words[i++]);
                builder.AddConclusion(var, term);
            }
        }

        public IOperationFactory OperationFactory { get; set; }

        private KnowledgeBaseManager _db;
    }

}