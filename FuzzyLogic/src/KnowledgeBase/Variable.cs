using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.Helpers;

namespace FuzzyLogic.KnowledgeBase
{
    class Variable:NamedObject
    {
        public Variable(string name) : base(name)
        {
            _terms = new HashSet<Term>();
        }


        private HashSet<Term> _terms;

    }
}
