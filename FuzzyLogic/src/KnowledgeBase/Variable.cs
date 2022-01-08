using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    public class Variable:IPrototype
    {
        public Variable(string name, bool isInput)
        {
            IsInput = isInput;
            Name = name;
            Terms = new List<Term>();
        }

        public Term AddTerm(string termName, IFunction func)
        {
            var term = Terms.FirstOrDefault(x => x.Name == termName);
            if (term != null)
                throw new InvalidOperationException($"Терм {termName} у переменной {Name} уже существует!");
            term = new Term(termName, func);
            Terms.Add(term);
            return term;
        }

        public void RemoveTerm(string term)
        {
            Terms.RemoveAll(x => x.Name.Equals(term));
        }
        public Term GetTerm(string term)
        {
            return Terms.First(t => t.Name == term);
        }

        public override string ToString()
        {
            return (IsInput ? "Входная" : "Выходная") + $" переменная \"{Name}\"";
        }

        public IPrototype Clone()
        {
            var clone = new Variable(Name, IsInput);
            clone.Terms.AddRange(Terms);
            return clone;
        }

        public string Name { get; }
        public bool IsInput { get; }
        public List<Term> Terms { get; }
    }
}
