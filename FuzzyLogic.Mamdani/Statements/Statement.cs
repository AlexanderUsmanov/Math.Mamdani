namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Значение нечеткой переменной (одно из выражений условия или заключения)
    /// </summary>
    public class Statement
    {
        public FuzzyVariable FuzzyVariable { get; }
        public Term Term { get; }

        public Statement(FuzzyVariable variable, Term term)
        {
            FuzzyVariable = variable;
            Term = term;
        }

        public new string ToString()
        {
            return FuzzyVariable.Name + "=" + Term.Name;
        }

        public string[] ToStringArray()
        {
            return new[] {FuzzyVariable.Name, Term.Name};
        }
    }
}
