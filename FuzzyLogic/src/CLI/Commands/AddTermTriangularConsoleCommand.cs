﻿using System;
using System.Collections.Generic;
using FuzzyLogic.KnowledgeBase.MembershipFunctions;

namespace FuzzyLogic.CLI.Commands
{
    public class AddTermTriangularConsoleCommand : AddTermConsoleCommand
    {
        public override string GetName()
        {
            return "AddTermTriangular";
        }

        public override string GetDescription()
        {
            return "Добавляет к переменной новый терм c треугольной функцией принадлежности";
        }

        protected override IFunction GetMembershipFunction(Dictionary<string, string> parameters)
        {
            var left = double.Parse(parameters[leftParam]);
            var сenter = double.Parse(parameters[centerParam]);
            var right = double.Parse(parameters[rightParam]);
            return new TriangularFunction(left, сenter, right);
        }

        protected override List<ConsoleCommandParam> GetParams()
        {
            var parameters = base.GetParams();

            Func<string, bool> numberValidator = x => double.TryParse(x, out _);
            string errorMsg = "Не число!";

            var left = new ConsoleCommandParam
            {
                Name = leftParam,
                AskForInput = "Введите координату левой точки основания",
                Description = "Координата левой точки основания"
            };
            left.AddValidator(numberValidator, errorMsg);
            parameters.Add(left);

            var center = new ConsoleCommandParam
            {
                Name = centerParam,
                AskForInput = "Введите координату вершины",
                Description = "Координата вершины"
            };
            center.AddValidator(numberValidator, errorMsg);
            parameters.Add(center);

            var right = new ConsoleCommandParam
            {
                Name = rightParam,
                AskForInput = "Введите координату правой точки основания",
                Description = "Координата правой точки основания"
            };
            right.AddValidator(numberValidator, errorMsg);
            parameters.Add(right);

            return parameters;
        }

        private string leftParam = "-left";
        private string centerParam = "-center";
        private string rightParam = "-right";
    }
}