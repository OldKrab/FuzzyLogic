using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.RuleBuilder;

namespace FuzzyLogic.KnowledgeBase
{
    class RuleParser
    {
        public RuleParser(KnowledgeBaseManager db, IOperationFactory operationFactory)
        {
            _db = db;
            _operationFactory = operationFactory;
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
                    builder.AddOperation(_operationFactory.CreateAndOperation());
                else if (words[i] == "OR")
                    builder.AddOperation(_operationFactory.CreateOrOperation());
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

        private IRuleBuilder builder;
        private IOperationFactory _operationFactory;
        private KnowledgeBaseManager _db;
    }

}