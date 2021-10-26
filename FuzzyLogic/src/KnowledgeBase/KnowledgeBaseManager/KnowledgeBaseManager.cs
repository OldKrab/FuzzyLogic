using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.KnowledgeBaseManager
{
    class KnowledgeBaseManager : IKnowledgeBaseManager
    {
        public KnowledgeBaseManager()
        {
            this.terms = new Dictionary<uint, Term>();
            this.inputVariables = new Dictionary<uint, Variable>();
            this.outputVariables = new Dictionary<uint, Variable>();
            this.conditions = new List<SingleCondition>();
            this.conclusions = new List<Conclusion>();
        }

        public Variable AddVariable(string name, bool isInputVar)
        {
            var variable = new Variable(name);
            if (isInputVar)
                inputVariables.Add(variable.Id, variable);
            else
                outputVariables.Add(variable.Id, variable);
            return variable;
        }

        public Term AddTerm(string name, IMembershipFunction func)
        {
            var term = new Term(name, func);
            terms.Add(term.Id, term);
            return term;
        }

        public Conclusion AddConclusion(uint varId, uint termId)
        {
            var conclusion = new Conclusion(outputVariables[varId], terms[termId]);
            conclusions.Add(conclusion);
            return conclusion;
        }

        public SingleCondition AddSingleCondition(uint varId, uint termId)
        {
            var condition = new SingleCondition(inputVariables[varId], terms[termId]);
            conditions.Add(condition);
            return condition;
        }

        private Dictionary<uint, Term> terms;
        private Dictionary<uint, Variable> inputVariables;
        private Dictionary<uint, Variable> outputVariables;
        private List<SingleCondition> conditions;
        private List<Conclusion> conclusions;
    }
}
