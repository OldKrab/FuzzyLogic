using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.Statements
{
    abstract class Statement
    {
        public Statement(Variable variable, Term term)
        {
            Term = term;
            Variable = variable;
        }

        public Term Term { get; }
        public Variable Variable { get; }

        public override string ToString()
        {
            return $"{{Variable: {Variable}, Term: {Term}}}";
        }
    }
}
