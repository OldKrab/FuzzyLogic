using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Statements;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase
{
    class Rule : IPrototype
    {
        public Rule(ConditionList condition, List<Statement> conclusions)
        {
            Condition = condition;
            Conclusions = conclusions;
        }

        public ConditionList Condition { get; private set; }
        public List<Statement> Conclusions { get; private set; }

        public IPrototype Clone()
        {
            var clone = (Rule)MemberwiseClone();
            clone.Condition = (ConditionList)Condition.Clone();
            clone.Conclusions = Conclusions.Select(c => (Statement)c.Clone()).ToList();
            return clone;
        }
    }
}