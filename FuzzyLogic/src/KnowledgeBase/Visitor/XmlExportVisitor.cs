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

        public void Clear() => _xml.Clear();


        public void Visit(KnowledgeBaseManager db)
        {
            AppendString("<KnowledgeBase>");
            AppendString("<Variables>");
            Tab();
            foreach (var variable in db.Variables)
            {
                Visit(variable);
            }
            UnTab();
            AppendString("</Variables>");
            AppendString("<Rules>");
            Tab();
            foreach (var rule in db.Rules)
            {
                Visit(rule);
            }
            UnTab();
            AppendString("</Rules>");
            AppendString("</KnowledgeBase>");

        }
        public void Visit(Variable variable)
        {
            AppendString("<Variable>"); 
            Tab();
            AppendString($"<Name>{variable.Name}</Name>");
            AppendString($"<IsInput>{variable.IsInput}</IsInput>");

            AppendString("<Terms>");
            Tab();
            foreach (var term in variable.Terms)
            {
                Visit(term);
            }
            UnTab();
            AppendString("</Terms>");
            UnTab(); 
            AppendString("</Variable>");
        }
        public void Visit(Term term)
        {
            AppendString("<Term>");
            Tab();
            AppendString($"<Name>{term.Name}</Name>");

            AppendString("<Function>");
            Tab();
            term.Function.Accept(this);
            UnTab();
            AppendString("</Function>");
            UnTab();
            AppendString("</Term>");
        }

        public void Visit(Rule rule)
        {
            AppendString("<Rule>");
            Tab();
            AppendString("<Condition>");
            Tab();
            rule.Condition.Accept(this);
            UnTab();
            AppendString("</Condition>");

            AppendString("<Conclusions>");
            Tab();
            foreach (var conclusion in rule.Conclusions)
            {
                AppendString("<Conclusion>");
                Visit(conclusion);
                AppendString("</Conclusion>");
            }
            UnTab();
            AppendString("</Conclusions>");
            UnTab();
            AppendString("</Rule>");
        }

        public void Visit(SingleCondition condition)
        {
            AppendString("<SingleCondition>");
            Tab();
            Visit((Statement) condition);
            UnTab();
            AppendString("</SingleCondition>");
        }

        public void Visit(ConditionList conditionList)
        {
            AppendString("<ConditionList>");
            Tab();
            conditionList.Conditions[0].Accept(this);
            for (int i = 1; i < conditionList.Conditions.Count; i++)
            {
                conditionList.Operations[i-1].Accept(this);
                conditionList.Conditions[i].Accept(this);
            }
            UnTab();
            AppendString("</ConditionList>");
        }

        public void Visit(TrapezoidFunction trapezoidFunc)
        {
            AppendString("<TrapezoidFunction>");
            Tab();
            AppendString($"<Left>{trapezoidFunc.Left}</Left>");
            AppendString($"<LeftCenter>{trapezoidFunc.LeftCenter}</LeftCenter>");
            AppendString($"<RightCenter>{trapezoidFunc.RightCenter}</RightCenter>");
            AppendString($"<Right>{trapezoidFunc.Right}</Right>");
            UnTab();
            AppendString("</TrapezoidFunction>");
        }

        public void Visit(TriangularFunction triangularFunc)
        {
            AppendString("<TriangularFunction>");
            Tab();
            AppendString($"<Left>{triangularFunc.Left}</Left>");
            AppendString($"<Center>{triangularFunc.Center}</Center>");
            AppendString($"<Right>{triangularFunc.Right}</Right>");
            UnTab();
            AppendString("</TriangularFunction>");
        }

        public void Visit(LinearFunction linearFunc)
        {
            AppendString("<LinearFunction>");
            Tab();
            AppendString($"<Left>{linearFunc.Left}</Left>");
            AppendString($"<Right>{linearFunc.Right}</Right>");
            AppendString($"<IsIncrease>{linearFunc.IsIncrease}</IsIncrease>");
            UnTab();
            AppendString("</LinearFunction>");
        }

        public void Visit(MinOperation op)
        {
            AppendString("<Operation>Min</Operation>");
        }

        public void Visit(MaxOperation op)
        {
            AppendString("<Operation>Max</Operation>");
        }

        public void Visit(ProdOperation op)
        {
            AppendString("<Operation>Prod</Operation>");
        }

        public void Visit(SumOperation op)
        {
            AppendString("<Operation>Sum</Operation>");
        }

        public void Visit(Statement statement)
        {
            AppendString($"<Var>{statement.Variable.Name}</Var>");
            AppendString($"<Term>{statement.Term.Name}</Term>");
        }


        private void AppendString(string str)
        {
            var tab = new string('\t', _tabsCount);
            _xml.Append(tab + str + "\n");
        }

        private void Tab() => _tabsCount++;
        private void UnTab() => _tabsCount--;

        private int _tabsCount;
        private readonly StringBuilder _xml = new StringBuilder();
    }
}
