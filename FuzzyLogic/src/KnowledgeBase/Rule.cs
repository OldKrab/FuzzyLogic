using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase
{
    public class Rule 
    {
        public Rule(ConditionList condition, List<Statement> conclusions)
        {
            Condition = condition;
            Conclusions = conclusions;
        }

        public ConditionList Condition { get; }
        public List<Statement> Conclusions { get; }

       
    }
}