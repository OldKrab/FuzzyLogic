using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.Reader
{
    public class KnowledgeBaseXmlReader
    {
        public KnowledgeBaseManager Read(string name)
        {
            var db = new KnowledgeBaseManager();
            var file = new FileStream(name, FileMode.Open);
            var settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
            var reader = XmlReader.Create(file, settings);
            ReadVariables(reader, db);
            ReadRules(reader, db);
            return db;
        }

        private void ReadRules(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            while (!(reader.Name == "Rules" && !reader.IsStartElement()))
                db.AddRule(ReadRule(reader, db));
            reader.ReadEndElement();
        }

        private Rule ReadRule(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();

            reader.ReadStartElement();
            ConditionList condition = ReadConditionList(reader, db);
            reader.ReadEndElement();

            List<Statement> conclusions = ReadConclusions(reader, db);

            reader.ReadEndElement();
            return new Rule(condition, conclusions);
        }

        private ICondition ReadCondition(XmlReader reader, KnowledgeBaseManager db)
        {
            var name = reader.Name;
            ICondition cond = name switch
            {
                "ConditionList" => ReadConditionList(reader, db),
                "SingleCondition" => ReadSingleCondition(reader, db),
                _ => throw new ArgumentException(@"Неизвестное условие")
            };
            return cond;
        }

        private List<Statement> ReadConclusions(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            List<Statement> conclusions = new List<Statement>();
            while (!(reader.Name == "Conclusions" && !reader.IsStartElement()))
                conclusions.Add(ReadConclusion(reader, db));

            reader.ReadEndElement();
            return conclusions;
        }

        private ConditionList ReadConditionList(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            ConditionList conditionList = new ConditionList();
            var condition = ReadCondition(reader, db);
            conditionList.AddCondition(condition);
            while (!(reader.Name == "ConditionList" && !reader.IsStartElement()))
            {
                var operation = ReadOperation(reader);
                condition = ReadCondition(reader, db);
                conditionList.AddCondition(condition, operation);
            }
            reader.ReadEndElement();
            return conditionList;
        }

        private SingleCondition ReadSingleCondition(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            var pars = ReadParams(reader, "SingleCondition");
            var variable = db.GetVariable(pars["Var"]);
            var term = variable.GetTerm(pars["Term"]);
            reader.ReadEndElement();
            return new SingleCondition(variable, term);
        }

        private Statement ReadConclusion(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            var pars = ReadParams(reader, "Conclusion");
            var variable = db.GetVariable(pars["Var"]);
            var term = variable.GetTerm(pars["Term"]);
            reader.ReadEndElement();
            return new Statement(variable, term);
        }

        private IOperation ReadOperation(XmlReader reader)
        {
            reader.ReadStartElement();
            string name = reader.ReadString();
            IOperation op = name switch
            {
                "Max" => new MaxOperation(),
                "Min" => new MinOperation(),
                "Prod" => new ProdOperation(),
                "Sum" => new SumOperation(),
                _ => throw new ArgumentException(@"Неизвестная операция")
            };
            reader.ReadEndElement();
            return op;
        }

        private void ReadVariables(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            while (!(reader.Name == "Variables" && !reader.IsStartElement()))
                ReadVariable(reader, db);
            reader.ReadEndElement();
        }

        private void ReadVariable(XmlReader reader, KnowledgeBaseManager db)
        {
            reader.ReadStartElement();
            string name = reader.ReadElementString();
            bool isInput = bool.Parse(reader.ReadElementString());
            ReadTerms(reader, out var terms);
            reader.ReadEndElement();

            db.AddVariable(name, isInput);
            foreach (var (termName, termFunc) in terms)
                db.AddTermToVariable(name, termName, termFunc);
        }

        private void ReadTerms(XmlReader reader, out List<(string, IFunction)> terms)
        {
            reader.ReadStartElement();
            terms = new List<(string, IFunction)>();
            while (!(reader.Name == "Terms" && !reader.IsStartElement()))
            {
                ReadTerm(reader, out var termName, out var termFunc);
                terms.Add((termName, termFunc));
            }
            reader.ReadEndElement();
        }

        private void ReadTerm(XmlReader reader, out string termName, out IFunction function)
        {
            reader.ReadStartElement();
            termName = reader.ReadElementString();
            function = ReadFunction(reader);
            reader.ReadEndElement();
        }

        private IFunction ReadFunction(XmlReader reader)
        {
            reader.ReadStartElement();
            var name = reader.Name;
            reader.ReadStartElement();
            var parameters = ReadParams(reader, name);

            IFunction func = name switch
            {
                "LinearFunction" => new LinearFunction(
                    double.Parse(parameters["Left"]),
                    double.Parse(parameters["Right"]),
                    bool.Parse(parameters["IsIncrease"])),
                "TriangularFunction" => new TriangularFunction(
                    double.Parse(parameters["Left"]),
                    double.Parse(parameters["Center"]),
                    double.Parse(parameters["Right"])),
                "TrapezoidFunction" => new TrapezoidFunction(
                    double.Parse(parameters["Left"]),
                    double.Parse(parameters["LeftCenter"]),
                    double.Parse(parameters["RightCenter"]),
                    double.Parse(parameters["Right"])),
                _ => throw new ArgumentException(@"Неизвестная функция")
            };
            reader.ReadEndElement();
            reader.ReadEndElement();
            return func;
        }

        private Dictionary<string, string> ReadParams(XmlReader reader, string elementName)
        {
            var parameters = new Dictionary<string, string>();
            while (!(reader.Name == elementName && !reader.IsStartElement()))
            {
                if (reader.IsStartElement())
                    parameters[reader.Name] = reader.ReadString();
                reader.Read();
            }

            return parameters;
        }
    }
}