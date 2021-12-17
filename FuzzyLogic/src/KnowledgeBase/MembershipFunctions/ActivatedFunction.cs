using FuzzyLogic.KnowledgeBase.Operations;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IFunction wrappedFunction, IOperation activation, double activatingValue)
            : base(wrappedFunction)
        {
            this.activation = activation;
            this.activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return activation.Evaluate(WrappedFunction.GetValue(x), activatingValue);
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
            return $"Activated function with activating value = {activatingValue} by operation [{activation}] and wrapped function:\n\t[{WrappedFunction}]";
        }

        private IOperation activation;
        private double activatingValue;
    }
}
