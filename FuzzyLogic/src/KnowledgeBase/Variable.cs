using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Variable:NamedObject
    {
        public Variable(string name) : base(name)
        {
            _terms = new HashSet<Term>();
        }

        public void AddTerm(string term, IFunction func)
        {
            _terms.Add(new Term(term, func));
        }
        public Term GetTerm(string term)
        {
            return _terms.First(t => t.Name == term);
        }

        private HashSet<Term> _terms;
    }
}
