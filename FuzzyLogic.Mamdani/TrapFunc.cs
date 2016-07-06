using FuzzyLogic.Mamdani.Exceptions;
using FuzzyLogic.Mamdani.Interfaces;

namespace FuzzyLogic.Mamdani
{
    /// <summary>
    /// Трапециевидная функция принадлежности
    /// </summary>
    public class TrapFunc : IAccessoryFunc
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        private readonly double _d;
        private double _activatedValue;

        public TrapFunc(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double GetValue(double x)
        {
            if (x <= _a)
            {
                return 0;
            }
            if (x >= _a && x < _b)
            {
                return (x - _a) / (_b - _a);
            }
            if (x >= _b && x <= _c)
            {
                return 1;
            }
            if (x > _c && x <= _d)
            {
                return (_d - x) / (_d - _c);
            }
            if (_d < x)
            {
                return 0;
            }
            throw new ArgumentOutOfBoundsException();
        }

        public IAccessoryFunc CopyFunc()
        {
            var func = new TrapFunc(_a, _b, _c, _d);
            return func;
        }

        public void SetActivatedValue(double x)
        {
            _activatedValue = x;
        }

        public double GetActivatedValue(double x)
        {
            return System.Math.Min(GetValue(x), _activatedValue);
        }

        public bool IsEqual(IAccessoryFunc func)
        {
            var trapFunc = func as TrapFunc;
            if (trapFunc == null)
                return false;

            return trapFunc.A == _a
                   && trapFunc.B == _b
                   && trapFunc.C == _c
                   && trapFunc.D == _d;
        }

        public double A { get { return _a; } }
        public double B { get { return _b; } }
        public double C { get { return _c; } }
        public double D { get { return _d; } }
    }
}
