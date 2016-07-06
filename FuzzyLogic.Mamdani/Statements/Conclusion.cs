using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Заключение
    /// </summary>
    public class Conclusion : Statement
    {
        public Conclusion(FuzzyVariable variable, Term term)
            : base(variable, term)
        {
        }

        public static Conclusion Create(string input, List<FuzzyVariable> variables)
        {
            Term term = null;
            FuzzyVariable variable = null;

            var splitResult = input.Split('=');
            if(splitResult.Length < 2)
                throw new ArgumentException("не найден симовл = в выражении", nameof(input));

            variable = variables.FirstOrDefault(x => x.Name == splitResult[0]);
            if(variable != null)
                term = variable.Terms.FirstOrDefault(x => x.Name == splitResult[1]);

            if (variable == null)
                throw new ArgumentException($"не найдена переменная {splitResult[0]}", nameof(input));

            if (term == null)
                throw new ArgumentException($"не найдено значение {splitResult[1]} переменной {splitResult[0]}", nameof(input));

            return new Conclusion(variable, term);
        }
    }
}
