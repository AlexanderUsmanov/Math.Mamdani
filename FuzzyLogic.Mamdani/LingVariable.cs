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


        private readonly List<Term> _termSet;

        public LingVariable(string name, List<Term> termSet)
        {
            Name = name;
            _termSet = termSet;
        }

        public bool HasTerm(string termName)
        {
            return _termSet.Any(x => x.Name == termName);
        }

        public Term GetTerm(string termName)
        {
            return _termSet.FirstOrDefault(x => x.Name == termName);
        }

        public double GetValueForTerm(Term term, double x)
        {
            return term.AccessoryFunc.GetValue(x);
        }
    }
}
