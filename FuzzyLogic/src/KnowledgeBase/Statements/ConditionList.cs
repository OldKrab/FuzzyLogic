using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    public class ConditionList : ICondition
    {
        public ConditionList(List<ICondition> conditions, List<IOperation> operations)
        {
            this.Conditions = conditions;
            this.Operations = operations;
        }

        public ConditionList(ICondition condition)
            : this(new List<ICondition> { condition }, new List<IOperation>())
        {

        }

        public ConditionList()
            : this(new List<ICondition>(), new List<IOperation>())
        {
        }

        public void AddCondition(ICondition condition, IOperation operation = null)
        {
            Conditions.Add(condition);
            if (operation != null)
                Operations.Add(operation);
        }

        public double Fuzzify(Dictionary<Variable, double> inputValues)
        {
            var res = Conditions[0].Fuzzify(inputValues);
            for (var i = 1; i < Conditions.Count; i++)
                res = Operations[i - 1].Evaluate(res, Conditions[i].Fuzzify(inputValues));
            return res;
        }

        public override string ToString()
        {
            var str = new StringBuilder($"({Conditions[0]})");
            for (var i = 1; i < Conditions.Count; i++)
                str.Append($" {Operations[i - 1]} ({Conditions[i]})");
            str.Append(")");
            return str.ToString();
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IPrototype Clone()
        {
            var clone = (ConditionList)MemberwiseClone();
            clone.Conditions = Conditions.Select(c => (ICondition)c.Clone()).ToList();
            clone.Operations = new List<IOperation>(Operations);
            return clone;
        }

        public List<ICondition> Conditions { get; private set; }
        public List<IOperation> Operations { get; private set; }
    }
}