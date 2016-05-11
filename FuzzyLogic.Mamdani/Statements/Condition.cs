using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Условие
    /// </summary>
    public class Condition : Statement
    {
        public Condition(LingVariable variable, Term term)
            : base(variable, term)
        {
        }

        public static Condition Create(string input, List<LingVariable> variables)
        {
            var splitResult = input.Split('=');
            if (splitResult.Length < 2)
                throw new ArgumentException("не найден симовл = в выражении", nameof(input));

            var variable = variables.FirstOrDefault(x => x.Name == splitResult[0]);
            var term = variable?.Terms.FirstOrDefault(x => x.Name == splitResult[1]);

            if (variable == null)
                throw new ArgumentException($"не найдена переменная {splitResult[0]}", nameof(input));

            if (term == null)
                throw new ArgumentException($"не найдено значение {splitResult[1]} переменной {splitResult[0]}", nameof(input));

            return new Condition(variable, term);
        }
    }
}
