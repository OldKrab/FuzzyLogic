using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    public partial class KnowledgeBaseManager
    {
        public List<Variable> InputVariables => Variables.Where(x => x.IsInput).ToList();
        public List<Variable> OutputVariables => Variables.Where(x => !x.IsInput).ToList();
        public List<Variable> Variables { get; private set; }
        public List<Rule> Rules { get; private set; }

        public KnowledgeBaseManager()
        {
            Rules = new List<Rule>();
            Variables = new List<Variable>();
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

        public void AddRule(Rule rule) => Rules.Add(rule);

        public Variable AddVariable(string name, bool isInput)
        {
            if (Variables.Exists(v => v.Name == name))
                throw new InvalidOperationException($"Переменная {name} уже существует!");

            var variable = new Variable(name, isInput);
            Variables.Add(variable);
            return variable;
        }

        public Variable AddInputVariable(string name) => AddVariable(name, true);

        public Variable AddOutputVariable(string name) => AddVariable(name, false);

        public void AddTermToVariable(string varName, string termName, IFunction termFunction) => GetVariable(varName).AddTerm(termName, termFunction);

        public void RemoveVariable(string name) => Variables.Remove(GetVariable(name));

        public void RemoveTermFromVariable(string varName, string termName) => GetVariable(varName).RemoveTerm(termName);

        public void RemoveRule(Rule rule) => Rules.Remove(rule);
       
        public Variable GetVariable(string name)
        {
            var variable = TryGetVariable(name);
            if (variable == null)
                throw new InvalidOperationException($"Переменной {name} не существует!");
            return variable;
        }

        public Variable TryGetVariable(string name)
        {
            var variable = Variables.FirstOrDefault(v => v.Name.Equals(name));
            return variable;
        }
    }
}
