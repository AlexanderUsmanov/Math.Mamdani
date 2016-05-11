namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Заключение
    /// </summary>
    public class Conclusion : Statement
    {
        public Conclusion(LingVariable variable, Term term)
            : base(variable, term)
        {
        }
    }
}
