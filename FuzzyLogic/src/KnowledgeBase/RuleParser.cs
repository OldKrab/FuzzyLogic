using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;

namespace FuzzyLogic.KnowledgeBase
{
    class RuleParser
    {
        public RuleParser(KnowledgeBaseManager db)
        {
            _db = db;
        }

        public void Parse(IRuleBuilder builder, string rule)
        {
            var words = rule.Split();
            int i = 1;
            while (i < words.Length && words[i] != "THEN")
            {
                if (words[i] == "(")
                    builder.StartConditionList();
                else if (words[i] == ")")
                    builder.EndConditionList();
                else if (words[i] == "AND")
                    builder.AddOperation(new MinOperation());
                else if (words[i] == "OR")
                    builder.AddOperation(new MaxOperation());
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

        private KnowledgeBaseManager _db;
    }

}