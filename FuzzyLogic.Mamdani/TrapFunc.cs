using FuzzyLogic.Mamdani.Exceptions;
using FuzzyLogic.Mamdani.Interfaces;

namespace FuzzyLogic.Mamdani
{
    //Трапециевидная функция принадлежности
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

        public string[] ToStringArray()
        {
            return new[] { _a.ToString(), _b.ToString(), _c.ToString(), _d.ToString() };
        }
    }
}
