
namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
   abstract class BaseDecoratorFunction : IFunction
    {
        protected BaseDecoratorFunction(IFunction wrappedFunction)
        {
            this.wrappedFunction = wrappedFunction;
        }
        public abstract double GetValue(double x);
        public abstract double GetMinValue();

        public abstract double GetMaxValue();

        protected IFunction wrappedFunction;
    }
}
