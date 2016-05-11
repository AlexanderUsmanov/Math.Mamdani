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
    }
}
