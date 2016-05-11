using System.Collections.Generic;
using FuzzyLogic.Mamdani.Interfaces;

namespace FuzzyLogic.Mamdani
{
    /// <summary>
    /// Возможное значение нечеткой переменной
    /// </summary>
    public class Term
    {
        public Term()
        {
        }

        public Term(string name, double a, double b, double c, double d)
        {
            Name = name;
            AccessoryFunc = new TrapFunc(a, b, c, d);
        }

        public IAccessoryFunc AccessoryFunc { get; set; }
        public string Name { get; set; }

        public Term Clone()
        {
            return new Term
            {
                AccessoryFunc = AccessoryFunc.CopyFunc(),
                Name = Name
            };
        }

        public string[] ToStringArray()
        {
            var list = new List<string> { Name };
            list.AddRange(AccessoryFunc.ToStringArray());
            return list.ToArray();
        }
    }
}
