using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IFunction wrappedFunction, IOperation activation, double activatingValue)
            : base(wrappedFunction)
        {
            this._activation = activation;
            this._activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return _activation.Evaluate(WrappedFunction.GetValue(x), _activatingValue);
        }

        public override double GetMinValue() => WrappedFunction.GetMinValue();

        public override double GetMaxValue() => WrappedFunction.GetMaxValue();

        private readonly IOperation _activation;
        private readonly double _activatingValue;
    }
}
