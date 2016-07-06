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
        public List<FuzzyVariable> Variables { get; }

        public ProblemConditions()
        {
            Variables = new List<FuzzyVariable>();
            Rules = new List<Rule>();
        }

        public ProblemConditions(List<FuzzyVariable> variables, List<Rule> rules)
        {
            Variables = variables;
            Rules = rules;
        }

        public int NumberOfConditions
        {
            get { return Rules.Select(x => x.Conditions.Count).Sum(); }
        }

        public int NumberOfConclusions
        {
            get { return Rules.Count; }
        }
        
        public void AddVariable(FuzzyVariable variable)
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
