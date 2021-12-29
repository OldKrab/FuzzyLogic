using System;
using System.Text;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Visitor
{
    class XmlExportVisitor : IKnowledgeVisitor
    {
        public String Xml => _xml.ToString();

        public void Parse(KnowledgeBaseManager db)
        {
            _xml.Append("<Rules>");
            foreach (var rule in db.Rules)
            {
               Parse(rule);
            }
            _xml.Append("</Rules>");
        }

        public void Parse(Rule rule)
        {
            _xml.Append("<Rule>");

            _xml.Append("<Condition>");
            rule.Condition.Accept(this);
            _xml.Append("</Condition>");

            _xml.Append("<Conclusions>");
            foreach (var conclusion in rule.Conclusions)
            {
                _xml.Append("<Conclusion>");
                ParseStatement(conclusion);
                _xml.Append("</Conclusion>");
            }

            _xml.Append("</Conclusions>");

            _xml.Append("</Rule>");
        }


        public void Visit(SingleCondition condition)
        {
            _xml.Append("<SingleCondition>");
            ParseStatement(condition);
            _xml.Append("</SingleCondition>");
        }

        public void Visit(ConditionList conditionList)
        {
            _xml.Append("<ConditionList>");
            conditionList.Conditions[0].Accept(this);
            for (int i = 1; i < conditionList.Conditions.Count; i++)
            {
                _xml.Append($"<Operation>{conditionList.Operations[i-1]}</Operation>");
                conditionList.Conditions[i].Accept(this);
            }
            _xml.Append("</ConditionList>");
        }

        public void Visit(TrapezoidFunction trapezoidFunc)
        {
            _xml.Append("<TrapezoidFunction>");
            _xml.Append($"<Left>{trapezoidFunc.Left}</Left>");
            _xml.Append($"<LeftCenter>{trapezoidFunc.LeftCenter}</LeftCenter>");
            _xml.Append($"<RightCenter>{trapezoidFunc.RightCenter}</RightCenter>");
            _xml.Append($"<Right>{trapezoidFunc.Right}</Right>");
            _xml.Append("</TrapezoidFunction>");
        }

        public void Visit(TriangularFunction triangularFunc)
        {
            _xml.Append("<TriangularFunction>");
            _xml.Append($"<Left>{triangularFunc.Left}</Left>");
            _xml.Append($"<Center>{triangularFunc.Center}</Center>");
            _xml.Append($"<Right>{triangularFunc.Right}</Right>");
            _xml.Append("</TriangularFunction>");
        }

        public void Visit(LinearFunction linearFunc)
        {
            _xml.Append("<LinearFunction>");
            _xml.Append($"<Left>{linearFunc.Left}</Left>");
            _xml.Append($"<Right>{linearFunc.Right}</Right>");
            _xml.Append("</LinearFunction>");
        }

        public void ParseStatement(Statement statement)
        {
            _xml.Append($"<Name>{statement.Variable.Name}</Name><Function>");
            statement.Term.Function.Accept(this);
            _xml.Append("</Function>");
        }

        private StringBuilder _xml = new StringBuilder();
    }
}
