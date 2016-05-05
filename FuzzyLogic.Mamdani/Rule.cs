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
        public List<Condition> Conditions { get; set; }
        public Conclusion Conclusion { get; set; }

        public void SetConditions(params Condition[] conditions)
        {
            Conditions = conditions.ToList();
        }

        public void SetConclusion(Conclusion conclusion)
        {
            Conclusion = conclusion;
        }
    }
}
