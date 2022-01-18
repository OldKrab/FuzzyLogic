using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IMembershipFunction wrappedFunction, IOperation activation, double activatingValue)
            : base(wrappedFunction)
        {
            this._activation = activation;
            this._activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return _activation.Evaluate(WrappedFunction.GetValue(x), _activatingValue);
        }

        public override double GetMinValue()
        {
            return WrappedFunction.GetMinValue();
        }

        public override double GetMaxValue()
        {
            return WrappedFunction.GetMaxValue();
        }

        public override string ToString()
        {
            return $"Activated function with activating value = {_activatingValue} by operation [{_activation}] and wrapped function:\n\t[{WrappedFunction}]";
        }

        private readonly IOperation _activation;
        private readonly double _activatingValue;
    }
}
