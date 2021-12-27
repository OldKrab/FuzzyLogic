using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.KnowledgeBase
{
    class KnowledgeBaseManager
    {
        public List<Variable> InputVariables { get; } = new List<Variable>();
        public List<Variable> OutputVariables { get; } = new List<Variable>();
        public List<Rule> Rules { get; } = new List<Rule>();

        public static KnowledgeBaseManager GetInstance()
        {
            return _instance ??= new KnowledgeBaseManager();
        }

        public Variable AddInputVariable(string name)
        {
            var variable = new Variable(name);
            InputVariables.Add(variable);
            return variable;
        }

        public Variable AddOutputVariable(string name)
        {
            var variable = new Variable(name);
            OutputVariables.Add(variable);
            return variable;
        }

        public Variable GetInputVariable(string name) => InputVariables.First(v => v.Name.Equals(name));

        public Variable GetOutputVariable(string name) => OutputVariables.First(v => v.Name.Equals(name));

       
        private static KnowledgeBaseManager _instance;
    }
}
