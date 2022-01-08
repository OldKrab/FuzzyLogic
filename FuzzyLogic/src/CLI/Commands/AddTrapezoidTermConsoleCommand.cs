using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.CLI.Commands
{
    public class AddTrapezoidTermConsoleCommand : AddTermConsoleCommand
    {
        public override string GetName()
        {
            return "AddTrapezoidTerm";
        }

        public override string GetDescription()
        {
            return "Добавляет к переменной новый терм c трапециевидной функцией принадлежности";
        }

        protected override IFunction GetMembershipFunction(Dictionary<string, string> parameters)
        {
            var left = double.Parse(parameters[leftParam]);
            var leftCenter = double.Parse(parameters[leftCenterParam]);
            var rightCenter = double.Parse(parameters[rightCenterParam]);
            var right = double.Parse(parameters[rightParam]);
            return new TrapezoidFunction(left, leftCenter, rightCenter, right);
        }

        protected override List<ConsoleCommandParam> CreateParams()
        {
            var parameters = base.CreateParams();

            Func<string, bool> numberValidator = x => double.TryParse(x, out _);
            string errorMsg = "Не число!";

            var left = new ConsoleCommandParam
            {
                Name = leftParam,
                AskForInput = "Введите координату левой точки нижнего основания",
                Description = "Координата левой точки нижнего основания"
            };
            left.AddValidator(numberValidator, errorMsg);
            parameters.Add(left);

            var leftCenter = new ConsoleCommandParam
            {
                Name = leftCenterParam,
                AskForInput = "Введите координату левой точки верхнего основания",
                Description = "Координата левой точки верхнего основания"
            };
            leftCenter.AddValidator(numberValidator, errorMsg);
            parameters.Add(leftCenter);

            var rightCenter = new ConsoleCommandParam
            {
                Name = rightCenterParam,
                AskForInput = "Введите координату правой точки верхнего основания",
                Description = "Координата правой точки верхнего основания"
            };
            rightCenter.AddValidator(numberValidator, errorMsg);
            parameters.Add(rightCenter);

            var right = new ConsoleCommandParam
            {
                Name = rightParam,
                AskForInput = "Введите координату правой точки нижнего основания",
                Description = "Координата правой точки нижнего основания"
            };
            right.AddValidator(numberValidator, errorMsg);
            parameters.Add(right);

            return parameters;
        }

        private string leftParam = "-left";
        private string leftCenterParam = "-leftCenter";
        private string rightCenterParam = "-rightCenter";
        private string rightParam = "-right";
    }
}