using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.Mamdani
{
    /// <summary>
    /// Нечеткая переменная
    /// </summary>
    public class LingVariable
    {
        public string Name { get; }
        public int Id { get; set; }


        public readonly List<Term> Terms;

        public LingVariable(string name, List<Term> terms)
        {
            Name = name;
            Terms = terms;
        }

        public double GetValueForTerm(Term term, double x)
        {
            return term.AccessoryFunc.GetValue(x);
        }

        public string[] ToStringArray()
        {
            var list = new List<string>
            {
                Name,
                string.Join(", ", Terms.Select(x => x.Name).ToArray())
            };
            return list.ToArray();
        }
    }
}
