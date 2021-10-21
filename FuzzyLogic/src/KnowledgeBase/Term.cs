using System;
using System.Collections.Generic;
using System.Text;
using FuzzyLogic.src.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.src.KnowledgeBase
{
    class Term: NamedObject
    {
        public Term(string name, IMembershipFunction function) : base(name)
        {
            MembershipFunction = function;  
        }

        public IMembershipFunction MembershipFunction { get; }
    }
}
