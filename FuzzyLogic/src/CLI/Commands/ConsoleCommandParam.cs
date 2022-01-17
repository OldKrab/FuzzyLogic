using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.CLI.Commands
{

    public class ConsoleCommandParam
    {
        public class Validator
        {
            public Func<string, bool> Function { get; set; }
            public string ErrorMessage { get; set; }
        }

        public ConsoleCommandParam()
        {
            AskForInput = "Введите значение";
        }

        public void AddValidator(Func<string, bool> function, string errorMessage)
        {
            _validators.Add(new Validator{Function = function, ErrorMessage = errorMessage});
        }

        public bool IsValueValid(string value, out string error)
        {
            var trigValidator = _validators.FirstOrDefault(v => !v.Function(value));
            error = trigValidator?.ErrorMessage;
            return trigValidator == null;
        }

        public string Name { get; set; }
        public string AskForInput { get; set; }
        public string Description { get; set; }

        private readonly List<Validator> _validators = new List<Validator>();

       
    }
}