using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.src.KnowledgeBase.MembershipFunctions
{
   abstract class BaseDecoratorFunction : IMembershipFunction
    {
        protected BaseDecoratorFunction(IMembershipFunction wrappedFunction)
        {
            this.wrappedFunction = wrappedFunction;
        }
        public abstract double GetValue(double x);

        protected IMembershipFunction wrappedFunction;
    }
}
