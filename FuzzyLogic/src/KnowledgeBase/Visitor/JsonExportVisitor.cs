using System;
using System.Text;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Visitor
{
    class JsonExportVisitor : IKnowledgeVisitor
    {
        public String Json => _json.ToString();

        public void Visit(KnowledgeBaseManager db)
        {
            _json.Append("[");
            if (db.Rules.Count > 0)
                Visit(db.Rules[0]);
            for (var i = 1; i < db.Rules.Count; i++)
            {
                _json.Append(", ");
                var rule = db.Rules[i];
               Visit(rule);
            }

            _json.Append("]");
        }

        public void Visit(Rule rule)
        {
            _json.Append("{\"condition\":");
            rule.Condition.Accept(this);
            _json.Append(", \"conclusions\":[");
            if (rule.Conclusions.Count > 0)
                Visit( rule.Conclusions[0]);
            for (var i = 1; i < rule.Conclusions.Count; i++)
            {
                _json.Append(",");
                var conclusion = rule.Conclusions[i];
                Visit(conclusion);
            }

            _json.Append("]}");
        }


        public void Visit(SingleCondition condition)
        {
            _json.Append(
                "{" +
                    "\"type\":\"SingleCondition\", " +
                    "\"value\":");
            Visit((Statement)condition);
            _json.Append(
                "}");
        }

        public void Visit(ConditionList conditionList)
        {
            _json.Append(
                "{" +
                     "\"type\":\"ConditionList\", " +
                     "\"value\":{" +
                        "\"conditions\":[");
            if(conditionList.Conditions.Count > 0)
                conditionList.Conditions[0].Accept(this);
            for (var i = 1; i < conditionList.Conditions.Count; i++)
            {
                _json.Append(", ");
                var condition = conditionList.Conditions[i];
                condition.Accept(this);
            }

            _json.Append("]}");
            _json.Append("}");
        }

        public void Visit(TrapezoidFunction trapezoidFunc)
        {
            _json.Append(
                "{" +
                    "\"type\":\"TrapezoidFunction\", " +
                    "\"value\":{" +
                        $"\"Left\":\"{trapezoidFunc.Left}\", " +
                        $"\"LeftCenter\":\"{trapezoidFunc.LeftCenter}\", " +
                        $"\"RightCenter\":\"{trapezoidFunc.RightCenter}\", " +
                        $"\"Right\":\"{trapezoidFunc.Right}\"" +
                    "}" +
                "}");
        }

        public void Visit(TriangularFunction triangularFunc)
        {
            _json.Append(
                "{" +
                    "\"type\":\"TriangularFunction\", " +
                    "\"value\":{" +
                        $"\"Left\":\"{triangularFunc.Left}\", " +
                        $"\"Center\":\"{triangularFunc.Center}\", " +
                        $"\"Right\":\"{triangularFunc.Right}\"" +
                    "}" +
                "}");
        }

        public void Visit(LinearFunction linearFunc)
        {
            _json.Append(
                "{" +
                    "\"type\":\"LinearFunction\", " +
                    "\"value\":{" +
                        $"\"Left\":\"{linearFunc.Left}\", " +
                        $"\"Right\":\"{linearFunc.Right}\", " +
                        $"\"IsIncrease\":\"{linearFunc.IsIncrease}\"" +
                    "}" +
                "}");
        }

        public void Visit(MinOperation op)
        {
            throw new NotImplementedException();
        }

        public void Visit(MaxOperation op)
        {
            throw new NotImplementedException();
        }

        public void Visit(ProdOperation op)
        {
            throw new NotImplementedException();
        }

        public void Visit(SumOperation op)
        {
            throw new NotImplementedException();
        }

        public void Visit(Statement statement)
        {
            _json.Append($@"{{""variable"":""{statement.Variable.Name}"", ""function"":");
            statement.Term.Function.Accept(this);
            _json.Append("}");
        }

        private StringBuilder _json = new StringBuilder();
    }
}
