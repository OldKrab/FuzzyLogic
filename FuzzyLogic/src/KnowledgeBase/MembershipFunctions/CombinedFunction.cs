using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuzzyLogic.KnowledgeBase.Operations;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class CombinedFunction : IFunction
    {
        public CombinedFunction(IOperation combination, List<IFunction> functions)
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

        public double GetMinValue() => _functions.Min(f => f.GetMinValue());

        public double GetMaxValue() => _functions.Max(f => f.GetMaxValue());

        private readonly IOperation _combination;
        private readonly List<IFunction> _functions;
    }
}
