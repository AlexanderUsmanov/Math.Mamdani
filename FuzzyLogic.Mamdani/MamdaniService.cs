using System.Text;
using FuzzyLogic.Mamdani.Exceptions;
using FuzzyLogic.Mamdani.Interfaces;
using FuzzyLogic.Mamdani.Problems;

namespace FuzzyLogic.Mamdani
{
    public class MamdaniService : IMamdaniService
    {
        private StringBuilder _logBuilder;

        public double SolveProblem(Problem problem)
        {
            _logBuilder = new StringBuilder();

            var fuzzificationResult = Fuzzificate(problem);
            var aggregationResult = Aggregate(problem, fuzzificationResult);
            var compositionResult = Composite(problem, aggregationResult);
            var defuzzificationResult = Defuzzificate(compositionResult);

            return defuzzificationResult;
        }

        public double SolveProblem(ProblemConditions conditions, double[] input)
        {
            var problem = new Problem
            {
                InputData = input,
                ProblemConditions = conditions
            };
            return SolveProblem(problem);
        }

        public string GetLog => _logBuilder?.ToString();

        private double[] Fuzzificate(Problem problem)
        {
            if(problem.InputData == null)
                throw new ArgumentOutOfBoundsException();
            if (problem.InputData.Length != problem.ProblemConditions.Variables.Count - 1)
                throw new ArgumentOutOfBoundsException();

            double[] result = new double[problem.ProblemConditions.NumberOfConditions];
            int i = 0;

            _logBuilder.AppendLine("Начало процедуры фаззификации");

            foreach (var rule in problem.ProblemConditions.Rules)
            {
                foreach (var condition in rule.Conditions)
                {
                    var id = condition.LingVariable.Id;
                    var variable = condition.LingVariable;
                    result[i] = variable.GetValueForTerm(condition.Term, problem.InputData[id]);
                    _logBuilder.Append(variable.Name + " : " + result[i] + " ");
                    i++;
                }
                _logBuilder.AppendLine();
            }

            _logBuilder.AppendLine("Процедура фаззификации завершена");
            return result;
        }

        private double[] Aggregate(Problem problem, double[] fuzzificationResult)
        {
            int i = 0;
            int j = 0;
            double[] result = new double[problem.ProblemConditions.NumberOfConclusions];

            _logBuilder.AppendLine("Начало процедуры аггрегации");

            foreach (var rule in problem.ProblemConditions.Rules)
            {
                double truthOfConditions = 1.0;
                foreach (var condition in rule.Conditions)
                {
                    truthOfConditions = System.Math.Min(truthOfConditions, fuzzificationResult[i]);
                    i++;
                }
                result[j] = truthOfConditions;
                _logBuilder.Append(result[j] + " ");
                j++;
            }
            _logBuilder.AppendLine();
            _logBuilder.AppendLine("Процедура аггрегации завершена");

            return result;
        }

        private UnionOfTerms Composite(Problem problem, double[] aggregationResult)
        {
            var result = new UnionOfTerms();
            _logBuilder.AppendLine("Начало процедуры композиции");

            int i = 0;

            foreach (var rule in problem.ProblemConditions.Rules)
            {
                var term = rule.Conclusion.Term.Clone();
                term.AccessoryFunc.SetActivatedValue(aggregationResult[i]);
                result.Add(term);
                i++;
            }

            _logBuilder.AppendLine("Процедура композиции завершена");
            return result;
        }

        private double Defuzzificate(UnionOfTerms compositionResult)
        {
            double x, y1 = 0.0, y2 = 0.0, step = 0.01;

            _logBuilder.AppendLine("Начало процедуры дефаззификации");

            for (x = 0.0; x <= 1.0; x += step)
            {
                y1 += x * compositionResult.MaxValue(x);
            }
            for (x = 0.0; x <= 1.0; x += step)
            {
                y2 += compositionResult.MaxValue(x);
            }

            _logBuilder.AppendLine("Результат: " + (y1/y2));
            _logBuilder.AppendLine("Процедура дефаззификации завершена");

            return y1 / y2;
        }
    }
}
