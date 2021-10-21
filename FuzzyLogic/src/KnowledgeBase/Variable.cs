using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase
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
