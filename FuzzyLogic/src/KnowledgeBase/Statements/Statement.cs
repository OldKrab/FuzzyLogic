﻿namespace FuzzyLogic.KnowledgeBase.Statements
{
    abstract class Statement
    {
        protected Statement(Variable variable, Term term)
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
