using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;
using FuzzyLogic.KnowledgeBase.Statements;

namespace FuzzyLogic.KnowledgeBase.KnowledgeBaseManager
{
    class KnowledgeBaseManager
    {
        public static KnowledgeBaseManager GetInstance()
        {
            if (instance == null)
                Console.WriteLine("Create instance");
            else
                Console.WriteLine("Return existed");
            return instance ??= new KnowledgeBaseManager();
        }

        public Variable AddInputVariable(string name) => AddVariable(name, true);
        public Variable AddOutputVariable(string name) => AddVariable(name, false);
        public Variable GetInputVariable(string name) => inputVariables.Values.First(v => v.Name.Equals(name));
        public Variable GetOutputVariable(string name) => outputVariables.Values.First(v => v.Name.Equals(name));

        private KnowledgeBaseManager()
        {
            this.inputVariables = new Dictionary<uint, Variable>();
            this.outputVariables = new Dictionary<uint, Variable>();
        }
        private Variable AddVariable(string name, bool isInputVar)
        {
            var variable = new Variable(name);
            if (isInputVar)
                inputVariables.Add(variable.Id, variable);
            else
                outputVariables.Add(variable.Id, variable);
            return variable;
        }

        private Dictionary<uint, Variable> inputVariables;
        private Dictionary<uint, Variable> outputVariables;
        private static KnowledgeBaseManager instance;
    }
}
