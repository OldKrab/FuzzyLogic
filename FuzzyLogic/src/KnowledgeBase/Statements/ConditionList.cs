using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.Statements
{
    class ConditionList : ICondition
    {
        public ConditionList(List<ICondition> conditions, List<IOperation> operations)
        {
            Debug.Assert(conditions.Count == operations.Count + 1, "Conditions count do not match operations count");
            this.conditions = conditions;
            this.operations = operations;
        }

        public ConditionList(ICondition condition)
            : this(new List<ICondition> { condition }, new List<IOperation>()) { }

        public void AddCondition(ICondition condition, IOperation operation)
        {
            conditions.Add(condition);
            operations.Add(operation);
        }

        public double Fuzzify(Dictionary<Variable, double> inputValues)
        {
            var res = conditions[0].Fuzzify(inputValues);
            for (var i = 1; i < conditions.Count; i++)
                res = operations[i - 1].Evaluate(res, conditions[i].Fuzzify(inputValues));
            return res;
        }

        public override string ToString()
        {
            var str = new StringBuilder($"({conditions[0]})");
            for (var i = 1; i < conditions.Count; i++)
                str.Append($" {operations[i - 1]} ({conditions[i]})");
            str.Append(")");
            return str.ToString();
        }

        private List<ICondition> conditions;
        private List<IOperation> operations;
    }
}