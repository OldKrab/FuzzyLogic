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
        public List<Rule> Rules { get; private set;  } = new List<Rule>();
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

        public Variable AddVariable(string name, bool isInput)
        {
            var variable = Variables.FirstOrDefault(x => x.Name == name);
            if (variable != null)
                throw new ArgumentException("This var is already exists!");

            variable = new Variable(name, isInput);
            Variables.Add(variable);
            Console.WriteLine($"Added {variable}");
            return variable;
        }

        public Term AddTermToVariable(string varName, string termName, IFunction termFunction)
        {
            var variable = GetVariable(varName);
            var term = variable.AddTerm(termName, termFunction);
            Console.WriteLine($"To \"{variable}\" added \"{term}\"");
            return term;
        }

        public void RemoveVariable(string name)
        {
            Variables.RemoveAll(x => x.Name.Equals(name));
            Console.WriteLine($"Removed var \"{name}\"");
        }
        public void RemoveTermFromVariable(string varName,string termName)
        {
            var variable = GetVariable(varName);
            variable.RemoveTerm(termName);
            Console.WriteLine($"From \"{variable}\" removed \"{termName}\"");
        }

        public Variable AddInputVariable(string name)
        {
            return AddVariable(name, true);
        }

        public Variable AddOutputVariable(string name)
        {
            return AddVariable(name, false);
        }

        public Variable GetVariable(string name) => Variables.First(v => v.Name.Equals(name));


        private static KnowledgeBaseManager _instance;
    }
}
