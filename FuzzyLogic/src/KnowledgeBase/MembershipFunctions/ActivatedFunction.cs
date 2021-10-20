using FuzzyLogic.src.KnowledgeBase.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions
{
    class ActivatedFunction : BaseDecoratorFunction
    {
        public ActivatedFunction(IMembershipFunction wrappedFunction, IOperation activation, double activatingValue)
            :base(wrappedFunction)
        {
            this.activation = activation;
            this.activatingValue = activatingValue;
        }
        public override double GetValue(double x)
        {
            return activation.Evaluate(wrappedFunction.GetValue(x), activatingValue);
        }

        private IOperation activation;
        private double activatingValue; 
    }
}
