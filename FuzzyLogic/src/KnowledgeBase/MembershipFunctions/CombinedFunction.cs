using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class CombinedFunction : IFunction
    {
        public CombinedFunction(IOperation combination, List<IFunction> functions)
        {
            this._combination = combination;
            this._functions = functions;
        }

        public CombinedFunction(IOperation combination, IFunction function)
        {
            this._combination = combination;
            this._functions = new List<IFunction>();
            AddFunction(function);
        }

        public void AddFunction(IFunction function)
        {
            _functions.Add(function);
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
            str.Append("]");
            return str.ToString();
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            throw new System.NotImplementedException();
        }

        private IOperation _combination;
        private List<IFunction> _functions;
    }
}
