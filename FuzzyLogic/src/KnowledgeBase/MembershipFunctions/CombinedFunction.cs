using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class CombinedFunction : IFunction
    {
        public CombinedFunction(IOperation combination, List<IFunction> functions)
        {
            this.combination = combination;
            this.functions = functions;
        }

        public CombinedFunction(IOperation combination, IFunction function)
        {
            this.combination = combination;
            this.functions = new List<IFunction>();
            AddFunction(function);
        }

        public void AddFunction(IFunction function)
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

        public double GetMinValue()
        {
            return functions.Min(f => f.GetMinValue());
        }

        public double GetMaxValue()
        {
            return functions.Max(f => f.GetMaxValue());
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Combined function with operation [{combination}] and functions:\n[\n");
            for (int i = 0; i < functions.Count; i++)
                str.Append($"{i + 1}) {functions[i]}\n");
            str.Append("]");
            return str.ToString();
        }

        private IOperation combination;
        private List<IFunction> functions;
    }
}
