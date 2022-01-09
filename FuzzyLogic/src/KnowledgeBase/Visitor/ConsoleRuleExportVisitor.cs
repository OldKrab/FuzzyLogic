using System;
using System.Text;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Visitor
{
    class ConsoleRuleExportVisitor : IKnowledgeVisitor
    {
        public String Text => _text.ToString();

        public void Clear() => _text.Clear();


        public void Parse(Rule rule)
        {
            AppendString("IF ");
            Visit(rule.Condition, false);
            AppendString(" THEN ");

            foreach (var conclusion in rule.Conclusions)
            {
                Parse(conclusion);
                AppendString(" ");
            }
        }

        public void Visit(SingleCondition condition) => Parse(condition);
        public void Visit(ConditionList conditionList)
        {
            Visit(conditionList, true);
        }

        public void Visit(ConditionList conditionList, bool parenthesis)
        {
            if (parenthesis) AppendString("(");
            conditionList.Conditions[0].Accept(this);
            for (int i = 1; i < conditionList.Conditions.Count; i++)
            {
                conditionList.Operations[i - 1].Accept(this);
                conditionList.Conditions[i].Accept(this);
            }
            if (parenthesis) AppendString(")");
        }

        public void Visit(TrapezoidFunction trapezoidFunc) { }

        public void Visit(TriangularFunction triangularFunc) { }

        public void Visit(LinearFunction linearFunc) { }

        public void Visit(MinOperation op) => Parse(op);

        public void Visit(MaxOperation op) => Parse(op);

        public void Visit(ProdOperation op) => Parse(op);

        public void Visit(SumOperation op) => Parse(op);

        public void Parse(Statement statement) => AppendString($"{statement.Variable.Name} {statement.Term.Name}");

        public void Parse(IOrOperation op) => AppendString($" OR ");

        public void Parse(IAndOperation op) => AppendString($" AND ");

        private void AppendString(string str) => _text.Append(str);

        private StringBuilder _text = new StringBuilder();
    }
}
