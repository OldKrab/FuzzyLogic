using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase
{
    class Rule : IPrototype
    {
        public Rule(ICondition condition, List<Conclusion> conclusions)
        {
            Condition = condition;
            Conclusions = conclusions;
        }

        public ICondition Condition { get; private set; }
        public List<Conclusion> Conclusions { get; private set; }

        public IPrototype Clone()
        {
            var clone = (Rule)MemberwiseClone();
            clone.Condition = (ICondition)Condition.Clone();
            clone.Conclusions = Conclusions.Select(c => (Conclusion)c.Clone()).ToList();
            return clone;
        }
    }
}