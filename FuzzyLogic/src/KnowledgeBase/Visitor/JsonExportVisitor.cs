﻿using System;
using System.Text;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Visitor
{
    class JsonExportVisitor : IKnowledgeVisitor
    {
        public String Json => _json.ToString();

        public void Parse(KnowledgeBaseManager db)
        {
            _json.Append("[");
            if (db.Rules.Count > 0)
                Parse(db.Rules[0]);
            for (var i = 1; i < db.Rules.Count; i++)
            {
                _json.Append(", ");
                var rule = db.Rules[i];
               Parse(rule);
            }

            _json.Append("]");
        }

        public void Parse(Rule rule)
        {
            _json.Append("{\"condition\":");
            rule.Condition.Accept(this);
            _json.Append(", \"conclusions\":[");
            if (rule.Conclusions.Count > 0)
                Parse( rule.Conclusions[0]);
            for (var i = 1; i < rule.Conclusions.Count; i++)
            {
                _json.Append(",");
                var conclusion = rule.Conclusions[i];
                Parse(conclusion);
            }

            _json.Append("]}");
        }


        public void Visit(SingleCondition condition)
        {
            _json.Append(
                "{" +
                    "\"type\":\"SingleCondition\", " +
                    "\"value\":");
            Parse((Statement)condition);
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

        public void Parse(Statement statement)
        {
            _json.Append($@"{{""variable"":""{statement.Variable.Name}"", ""function"":");
            statement.Term.Function.Accept(this);
            _json.Append("}");
        }

        private StringBuilder _json = new StringBuilder();
    }
}
