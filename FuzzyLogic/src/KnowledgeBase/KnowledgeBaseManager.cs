using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    public class KnowledgeBaseManager
    {
        public List<Variable> InputVariables => Variables.Where(x => x.IsInput).ToList();
        public List<Variable> OutputVariables => Variables.Where(x => !x.IsInput).ToList();
        public List<Variable> Variables { get; }
        public List<Rule> Rules { get; }
        public string Name { get; set; }

        public KnowledgeBaseManager()
        {
            Rules = new List<Rule>();
            Variables = new List<Variable>();
            Name = "";
        }

        public void AddRule(Rule rule)
            => Rules.Add(rule);

        public Variable AddVariable(string name, bool isInput, double minValue, double maxValue)
        {
            if (Variables.Exists(v => v.Name == name))
                throw new InvalidOperationException($"Переменная {name} уже существует!");

            var variable = new Variable(name, isInput, minValue, maxValue);
            Variables.Add(variable);
            return variable;
        }

        public void AddTermToVariable(string varName, string termName, IMembershipFunction termFunction) 
            => GetVariable(varName).AddTerm(termName, termFunction);

        public void RemoveVariable(string name)
            => Variables.Remove(GetVariable(name));

        public void RemoveTermFromVariable(string varName, string termName)
            => GetVariable(varName).RemoveTerm(termName);

        public void RemoveRule(Rule rule)
            => Rules.Remove(rule);

        public void RemoveRule(int index)
            => Rules.RemoveAt(index);
       
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
