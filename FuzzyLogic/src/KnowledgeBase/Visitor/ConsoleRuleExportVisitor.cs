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


        public void Visit(Rule rule)
        {
            AppendString("IF ");
            Visit(rule.Condition, false);
            AppendString(" THEN ");

            foreach (var conclusion in rule.Conclusions)
            {
                Visit(conclusion);
                AppendString(" ");
            }
        }

        public void Visit(SingleCondition condition) => Visit((Statement) condition);
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

        public void Visit(MinOperation op) => Visit((IAndOperation) op);

        public void Visit(MaxOperation op) => Visit((IOrOperation) op);

        public void Visit(ProdOperation op) => Visit((IAndOperation) op);

        public void Visit(SumOperation op) => Visit((IOrOperation) op);

        public void Visit(Statement statement) => AppendString($"{statement.Variable.Name} {statement.Term.Name}");

        public void Visit(IOrOperation op) => AppendString(" OR ");

        public void Visit(IAndOperation op) => AppendString(" AND ");

        private void AppendString(string str) => _text.Append(str);

        private readonly StringBuilder _text = new StringBuilder();
    }
}
