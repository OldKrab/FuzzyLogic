using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    partial class KnowledgeBaseManager
    {
        public List<Variable> InputVariables => Variables.Where(x => x.IsInput).ToList();
        public List<Variable> OutputVariables => Variables.Where(x => !x.IsInput).ToList();
        public List<Variable> Variables { get; private set; } = new List<Variable>();
        public List<Rule> Rules { get; private set; } = new List<Rule>();
        public static KnowledgeBaseManager GetInstance()
        {
            return _instance ??= new KnowledgeBaseManager();
        }

        public void Restore(ISnapshot snapshot)
        {
            var baseSnapshot = (KnowledgeBaseSnapshot)snapshot;
            Variables = baseSnapshot.Variables;
            Rules = baseSnapshot.Rules;
        }

        public ISnapshot MakeSnapshot()
        {
            return new KnowledgeBaseSnapshot(
                Variables.Select(x => (Variable)x.Clone()).ToList(),
                Rules.Select(r => (Rule)r.Clone()).ToList());
        }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }

        public Variable AddVariable(string name, bool isInput)
        {
            if (Variables.Exists(v => v.Name == name))
                throw new InvalidOperationException($"Переменная {name} уже существует!");

            var variable = new Variable(name, isInput);
            Variables.Add(variable);
            Console.WriteLine($"Добавлена {variable}");
            return variable;
        }

        public Term AddTermToVariable(string varName, string termName, IFunction termFunction)
        {
            var variable = GetVariable(varName);
            var term = variable.AddTerm(termName, termFunction);
            Console.WriteLine($"К \"{variable}\" добавлен \"{term}\"");
            return term;
        }

        public void RemoveVariable(string name)
        {
            var variable = GetVariable(name);
            Variables.Remove(variable);
            Console.WriteLine($"Удалена переменная \"{name}\"");
        }
        public void RemoveTermFromVariable(string varName, string termName)
        {
            var variable = GetVariable(varName);
            variable.RemoveTerm(termName);
            Console.WriteLine($"У \"{variable}\" удален \"{termName}\"");
        }

        public Variable AddInputVariable(string name)
        {
            return AddVariable(name, true);
        }

        public Variable AddOutputVariable(string name)
        {
            return AddVariable(name, false);
        }

        public Variable GetVariable(string name)
        {
            var variable = Variables.FirstOrDefault(v => v.Name.Equals(name));
            if (variable == null)
                throw new InvalidOperationException($"Переменной {name} не существует!");
            return variable;
        }


        private static KnowledgeBaseManager _instance;
    }
}
