using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.CLI.Commands
{
    public class AddLinearTermConsoleCommand : AddTermConsoleCommand
    {
        public override string GetName()
        {
            return "AddLinearTerm";
        }

        public override string GetDescription()
        {
            return "Добавляет к переменной новый терм c линейной (возрастающей или убывающей) функцией принадлежности";
        }

        protected override IFunction GetMembershipFunction(Dictionary<string, string> parameters)
        {
            var left = double.Parse(parameters[leftParam]);
            var right = double.Parse(parameters[rightParam]);
            var isIncrease = parameters[monotonyParam] == "increase";
            return new LinearFunction(left, right, isIncrease);
        }

        protected override List<ConsoleCommandParam> CreateParams()
        {
            var parameters = base.CreateParams();

            Func<string, bool> numberValidator = x => double.TryParse(x, out _);
            string errorMsg = "Не число!";

            var left = new ConsoleCommandParam
            {
                Name = leftParam,
                AskForInput = "Введите координату левой точки",
                Description = "Координата левой точки линейной функции"
            };
            left.AddValidator(numberValidator, errorMsg);
            parameters.Add(left);

            var right = new ConsoleCommandParam
            {
                Name = rightParam,
                AskForInput = "Введите координату правой точки",
                Description = "Координата правой точки линейной функции"
            };
            right.AddValidator(numberValidator, errorMsg);
            parameters.Add(right);

            var monotony = new ConsoleCommandParam
            {
                Name = monotonyParam,
                AskForInput = "Введите тип монотонности (increase, decrease)",
                Description = "Тип монотонности линейной функции. Допустимые значения: increase, decrease"
            };
            monotony.AddValidator(s=> s == "decrease" || s == "increase", "Ожидалось increase или decrease!");
            parameters.Add(monotony);

            return parameters;
        }

        private string leftParam = "-left";
        private string rightParam = "-right";
        private string monotonyParam = "-monotony";
    }
}