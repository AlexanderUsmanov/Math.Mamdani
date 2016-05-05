using System.Collections.Generic;
using FuzzyLogic.Mamdani.Exceptions;

namespace FuzzyLogic.Mamdani.Statements
{
    /// <summary>
    /// Значение нечеткой переменной
    /// </summary>
    public class Statement
    {
        public static Dictionary<string, LingVariable> Variables;

        public LingVariable LingVariable { get; }
        public Term Term { get; }

        public Statement(string variableName, string termName)
        {
            if(!Variables.ContainsKey(variableName))
                throw new HasNoThatVariableException();

            if (!Variables[variableName].HasTerm(termName))
                throw new HasNoThatTermException();

            LingVariable = Variables[variableName];
            Term = LingVariable.GetTerm(termName);
        }
    }
}
