using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.KnowledgeBase.KnowledgeBaseManager
{
    class KnowledgeBaseManager
    {
        public static KnowledgeBaseManager GetInstance()
        {
            return _instance ??= new KnowledgeBaseManager();
        }

        public Variable AddInputVariable(string name) => AddVariable(name, true);
        public Variable AddOutputVariable(string name) => AddVariable(name, false);
        public Variable GetInputVariable(string name) => _inputVariables.Values.First(v => v.Name.Equals(name));
        public Variable GetOutputVariable(string name) => _outputVariables.Values.First(v => v.Name.Equals(name));

        private KnowledgeBaseManager()
        {
            this._inputVariables = new Dictionary<uint, Variable>();
            this._outputVariables = new Dictionary<uint, Variable>();
        }
        private Variable AddVariable(string name, bool isInputVar)
        {
            var variable = new Variable(name);
            if (isInputVar)
                _inputVariables.Add(variable.Id, variable);
            else
                _outputVariables.Add(variable.Id, variable);
            return variable;
        }

        private Dictionary<uint, Variable> _inputVariables;
        private Dictionary<uint, Variable> _outputVariables;
        private static KnowledgeBaseManager _instance;
    }
}
