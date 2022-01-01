using System.Collections.Generic;

namespace FuzzyLogic.KnowledgeBase
{

    public interface ISnapshot
    {
        string Name { get; set; }
    }

    partial class KnowledgeBaseManager
    {
        private class KnowledgeBaseSnapshot : ISnapshot
        {
            public KnowledgeBaseSnapshot(List<Variable> variables, List<Rule> rules)
            {
                Variables = variables;
                Rules = rules;
            }

            public List<Variable> Variables { get; }
            public List<Rule> Rules { get; }
            public string Name { get; set; }

        }
    }
}