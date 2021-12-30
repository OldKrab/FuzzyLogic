using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Variable
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
                throw new ArgumentException("This term is already exists!");
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
            return (IsInput ? "Input" : "Output") + $" variable \"{Name}\"";
        }

        public string Name { get; }
        public bool IsInput { get; }
        public List<Term> Terms { get; }
    }
}
