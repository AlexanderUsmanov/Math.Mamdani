using System.Collections.Generic;
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
            list.Add(string.Join(" & ", Conditions));
            list.Add(Conclusion.ToString());

            return list.ToArray();
        }
    }
}
