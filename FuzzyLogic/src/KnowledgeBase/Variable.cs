using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    public class Variable
    {
        public Variable(string name, bool isInput)
        {
            IsInput = isInput;
            Name = name;
            Terms = new List<Term>();
        }

        public Term AddTerm(string termName, IFunction func)
        {
            if (Terms.Exists(t => t.Name == termName))
                throw new InvalidOperationException($"Терм {termName} у переменной {Name} уже существует!");
            var term = new Term(termName, func);
            Terms.Add(term);
            return term;
        }

        public void RemoveTerm(string termName)
        {
            var term = GetTerm(termName);
            Terms.Remove(term);
        }
        public Term GetTerm(string termName)
        {
            var term = Terms.FirstOrDefault(t => t.Name == termName);
            if (term == null)
                throw new InvalidOperationException($"У переменной {Name} нет терма {termName}!");
            return term;
        }

        public override string ToString()
        {
            return (IsInput ? "Входная" : "Выходная") + $" переменная \"{Name}\"";
        }

        public string Name { get; }
        public bool IsInput { get; }
        public List<Term> Terms { get; }
    }
}
