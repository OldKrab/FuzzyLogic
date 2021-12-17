using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    class ConditionList : ICondition
    {
        public ConditionList(List<ICondition> conditions, List<IOperation> operations)
        {
            Debug.Assert(conditions.Count == operations.Count + 1, "Conditions count do not match operations count");
            this._conditions = conditions;
            this._operations = operations;
        }

        public ConditionList(ICondition condition)
            : this(new List<ICondition> { condition }, new List<IOperation>()) { }

        public void AddCondition(ICondition condition, IOperation operation)
        {
            _conditions.Add(condition);
            _operations.Add(operation);
        }

        public double Fuzzify(Dictionary<Variable, double> inputValues)
        {
            var res = _conditions[0].Fuzzify(inputValues);
            for (var i = 1; i < _conditions.Count; i++)
                res = _operations[i - 1].Evaluate(res, _conditions[i].Fuzzify(inputValues));
            return res;
        }

        public override string ToString()
        {
            var str = new StringBuilder($"({_conditions[0]})");
            for (var i = 1; i < _conditions.Count; i++)
                str.Append($" {_operations[i - 1]} ({_conditions[i]})");
            str.Append(")");
            return str.ToString();
        }

        public IPrototype Clone()
        {
            var clone = (ConditionList)MemberwiseClone();
            clone._conditions = _conditions.Select(c => (ICondition)c.Clone()).ToList();
            clone._operations = new List<IOperation>(_operations);
            return clone;
        }

        private List<ICondition> _conditions;
        private List<IOperation> _operations;
    }
}