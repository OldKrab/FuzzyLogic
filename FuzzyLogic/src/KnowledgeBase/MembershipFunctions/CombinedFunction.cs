using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class CombinedFunction : IMembershipFunction
    {
        public CombinedFunction(IOperation combination, List<IMembershipFunction> functions)
        {
            _combination = combination;
            _functions = functions;
        }

        public double GetValue(double x)
        {
            double result = _functions[0].GetValue(x);
            for (int i = 1; i < _functions.Count; i++)
            {
                result = _combination.Evaluate(result, _functions[i].GetValue(x));
            }
            return result;
        }

        public double GetMinValue()
        {
            return _functions.Min(f => f.GetMinValue());
        }

        public double GetMaxValue()
        {
            return _functions.Max(f => f.GetMaxValue());
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Combined function with operation [{_combination}] and functions:\n[\n");
            for (int i = 0; i < _functions.Count; i++)
                str.Append($"{i + 1}) {_functions[i]}\n");
            str.Append(']');
            return str.ToString();
        }

        public void Accept(IKnowledgeVisitor visitor) { }

        private readonly IOperation _combination;
        private readonly List<IMembershipFunction> _functions;
    }
}
