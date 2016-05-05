using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogic.Mamdani.Problems
{
    /// <summary>
    /// Условия задачи
    /// </summary>
    public class ProblemConditions
    {
        public List<Rule> Rules { get; }
        public Dictionary<string, LingVariable> Variables { get; }

        public ProblemConditions()
        {
            Variables = new Dictionary<string, LingVariable>();
            Rules = new List<Rule>();
        }

        public int NumberOfConditions
        {
            get { return Rules.Select(x => x.Conditions.Count).Sum(); }
        }

        public int NumberOfConclusions
        {
            get { return Rules.Count; }
        }
        
        public void AddVariable(string variableName, LingVariable variable)
        {
            variable.Id = Variables.Count;
            Variables.Add(variableName, variable);
        }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }
    }
}
