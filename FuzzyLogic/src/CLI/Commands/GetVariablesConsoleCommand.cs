using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase;

namespace FuzzyLogic.CLI.Commands
{
    public class GetVariablesConsoleCommand : ConsoleCommand
    {
        public override string GetName()
        {
            return "GetVariables";
        }

        public override string GetDescription()
        {
            return "Выводит список всех переменных";
        }

        protected override void ExecuteWithValidParams(Dictionary<string, string> parameters)
        {
            KnowledgeBaseManager db = FuzzySystem.GetInstance().KnowledgeBase;
            Console.WriteLine("Входные переменные:");
            if (db.InputVariables.Count == 0)
                Console.WriteLine("Нет входных переменных.");
            foreach (var variable in db.InputVariables)
                Console.WriteLine($"{variable.Name}, интервал [{variable.MinValue}, {variable.MaxValue}]");
            
            Console.WriteLine("Выходные переменные:");
            if (db.OutputVariables.Count == 0)
                Console.WriteLine("Нет выходных переменных.");
            foreach (var variable in db.OutputVariables)
                Console.WriteLine($"{variable.Name}, интервал [{variable.MinValue}, {variable.MaxValue}]");
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            return new List<ConsoleCommandParam>();
        }
    }
}