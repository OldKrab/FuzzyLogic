using System;
using FuzzyLogic.KnowledgeBase.Visitor;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    public class TriangularFunction : IMembershipFunction
    {
        public TriangularFunction(double left, double center, double right)
        {
            if (left > center || center > right)
                throw new InvalidOperationException("Координаты треугольной функции не должны убывать!");
            Left = left;
            Center = center;
            Right = right;
        }

        public override string ToString()
        {
            return $"Треугольная функция с параметрами left={Left}, center={Center}, right={Right}";
        }

        public void Accept(IKnowledgeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public double GetValue(double x)
        {
            if (x < Left || x > Right)
                return 0;
            if (Math.Abs(x - Center) < 1e-6)
                return 1;
            if (x < Center)
                return (x - Left) / (Center - Left);
            return (Right - x) / (Right - Center);
        }

        public double GetMinValue()
        {
            return Left;
        }

        public double GetMaxValue()
        {
            return Right;
        }


        public double Left { get; }
        public double Center { get; }
        public double Right { get; }
    }
}
