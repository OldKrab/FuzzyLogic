using System;

namespace FuzzyLogic.KnowledgeBase.Operations
{
    enum OperationType
    {
        Max, Min, Prod, Sum
    }
     class OperationFactory
    {
        public static IOperation CreateOperation(OperationType operation)
        {
            switch (operation)
            {
                case OperationType.Max:
                    return new MaxOperation();
                case OperationType.Min:
                    return new MinOperation();
                case OperationType.Prod:
                    return new ProdOperation();
                case OperationType.Sum:
                    return new SumOperation();
                default:
                    throw new ArgumentException("Unknown operation");
            }
        }
    }
}