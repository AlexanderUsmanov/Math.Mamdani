namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Значение нечеткой переменной
    /// </summary>
    public class Statement
    {
        public LingVariable LingVariable { get; }
        public Term Term { get; }

        public Statement(LingVariable variable, Term term)
        {
            LingVariable = variable;
            Term = term;
        }

        public new string ToString()
        {
            return LingVariable.Name + "=" + Term.Name;
        }
    }
}
