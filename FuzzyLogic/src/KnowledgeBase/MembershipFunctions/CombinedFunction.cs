using FuzzyLogic.src.KnowledgeBase.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions
{
    class CombinedFunction : IMembershipFunction
    {
        public CombinedFunction(IOperation combination, List<IMembershipFunction> functions)
        {
            this.combination = combination;
            this.functions = functions;
        }

        public CombinedFunction(IOperation combination, IMembershipFunction function)
        {
            this.combination = combination;
            this.functions = new List<IMembershipFunction>();
            AddFunction(function);
        }

        public void AddFunction(IMembershipFunction function)
        {
            functions.Add(function);
        }

        public double GetValue(double x)
        {
            double result = functions[0].GetValue(x);
            for (int i = 1; i < functions.Count; i++)
            {
                result = combination.Evaluate(result, functions[i].GetValue(x));
            }
            return result;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Combined Function with operation \"{combination}\" and functions:\n");
            foreach (var func in functions)
                str.Append($"{func}\n");
            return str.ToString();
        }

        private IOperation combination;
        private List<IMembershipFunction> functions;
    }
}
