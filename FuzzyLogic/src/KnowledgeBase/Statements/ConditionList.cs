using System.Collections.Generic;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    public class ConditionList : ICondition
    {
        public ConditionList(List<ICondition> conditions, List<IOperation> operations)
        {
            Conditions = conditions;
            Operations = operations;
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

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public List<ICondition> Conditions { get; }
        public List<IOperation> Operations { get; }
    }
}