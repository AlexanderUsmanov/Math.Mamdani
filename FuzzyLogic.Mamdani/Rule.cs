using System;
using System.Collections.Generic;
using System.Linq;
using FuzzyLogic.Mamdani.Statements;

namespace FuzzyLogic.Mamdani
{
    /// <summary>
    /// Правило
    /// </summary>
    public class Rule
    {
        public readonly List<Condition> Conditions;
        public readonly Conclusion Conclusion;

        public Rule(List<Condition> conditions, Conclusion conclusion)
        {
            Conditions = conditions;
            Conclusion = conclusion;
        }

        public string[] ToStringArray()
        {
            var list = new List<string>();
            list.Add(string.Join(" & ", Conditions.Select(x => x.ToString()).ToArray()));
            list.Add(Conclusion.ToString());

            return list.ToArray();
        }

        public static Rule Create(string input, List<FuzzyVariable> variables)
        {
            var splitResult = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);

            if (splitResult.Length < 2)
                throw new ArgumentException("не найден разделитель => ", nameof(input));

            var conditionsStrings = splitResult[0].Split(new[] { " & " }, StringSplitOptions.RemoveEmptyEntries);
            var conditions = conditionsStrings.Select(x => Condition.Create(x, variables));

            var conclusion = Conclusion.Create(splitResult[1], variables);

            var statementsCount = conditions.Count() + 1;

            if(statementsCount != variables.Count)
                throw new ArgumentException($"некорректная входная строка, число выражений {statementsCount} не равно числу переменных {variables.Count}", nameof(input));

            return new Rule(conditions.ToList(), conclusion);
        }
    }
}
