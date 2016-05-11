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
        public List<LingVariable> Variables { get; }

        public ProblemConditions()
        {
            Variables = new List<LingVariable>();
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
        
        public void AddVariable(LingVariable variable)
        {
            variable.Id = Variables.Count;
            Variables.Add(variable);
        }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }
    }
}
