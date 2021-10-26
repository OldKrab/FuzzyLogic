using System;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.KnowledgeBaseManager
{
    class KnowledgeBaseManagerLogger : IKnowledgeBaseManager
    {
        public KnowledgeBaseManagerLogger(KnowledgeBaseManager realManager)
        {
            this.realManager = realManager;
        }
        public Variable AddVariable(string name, bool isInputVar)
        {
            var variable = realManager.AddVariable(name, isInputVar);
            Console.Out.WriteLine("Created " + (isInputVar ? "input" : "output") + $" variable: {variable}");
            return variable;
        }

        public Term AddTerm(string name, IMembershipFunction func)
        {
            var term = realManager.AddTerm(name, func);
            Console.WriteLine($"Created term: {term}");
            return term;
        }

        public Conclusion AddConclusion(uint varId, uint termId)
        {
            var conclusion = realManager.AddConclusion(varId, termId);
            Console.WriteLine($"Created conclusion: {conclusion}");
            return conclusion;
        }

        public SingleCondition AddSingleCondition(uint varId, uint termId)
        {
            var condition = realManager.AddSingleCondition(varId, termId);
            Console.WriteLine($"Created single condition: {condition}");
            return condition;
        }

        private KnowledgeBaseManager realManager;
    }
}
