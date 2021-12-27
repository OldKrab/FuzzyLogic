using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.Helpers;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.KnowledgeBase
{
    class Variable
    {
        public Variable(string name)
        {
            Name = name;
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

        public string Name { get; }

        private HashSet<Term> _terms;
    }
}
