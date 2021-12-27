using System;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
     class Function : IFunction
    {
        public Function(Func<double, double> func, double min, double max)
        {
            this._func = func;
            this._max = max;
            this._min = min;
        }

        public double GetValue(double x)
        {
            return _func(x);
        }

        public double GetMinValue()
        {
            return _min;
        }

        public double GetMaxValue()
        {
            return _max;
        }

        private readonly Func<double, double> _func;
        private readonly double _min;
        private readonly double _max;


        public void Accept(IKnowledgeVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}