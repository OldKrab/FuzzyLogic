using System;

namespace FuzzyLogic.KnowledgeBase.MembershipFunctions
{
    class TriangularFunction : IFunction
    {
        public TriangularFunction(double left, double center, double right)
        {
            this._left = left;
            this._center = center;
            this._right = right;
        }

        public override string ToString()
        {
            return $"Triangular function with left={_left}, center={_center}, right={_right}";
        }

        public double GetValue(double x)
        {
            if (x < _left || x > _right)
                return 0;
            if (Math.Abs(x - _center) < 1e-6)
                return 1;
            if (x < _center)
                return (x - _left) / (_center - _left);
            return (_right - x) / (_right - _center);
        }

        public double GetMinValue()
        {
            return _left;
        }

        public double GetMaxValue()
        {
            return _right;
        }


        private double _left, _center, _right;
    }
}
