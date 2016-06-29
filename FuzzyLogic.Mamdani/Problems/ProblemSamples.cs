using System;
using System.Collections.Generic;
using System.IO;
using FuzzyLogic.Mamdani.Exceptions;
using FuzzyLogic.Mamdani.Results;

namespace FuzzyLogic.Mamdani.Problems
{
    public static class ProblemSamples
    {
        public static Problem First()
        {
            var result = new Problem
            {
                InputData = new[] { 0.7, 0.83 },
                ProblemConditions = new ProblemConditions()
            };

            #region variables
            var terms1 = new List<Term>
            {
                new Term("низкий", 0, 0, 0.3, 0.4),
                new Term("средний", 0.3, 0.4, 0.6, 0.7),
                new Term("высокий", 0.6, 0.7, 1, 1)
            };
            var x1 = new LingVariable("X1", terms1);
            result.ProblemConditions.AddVariable(x1);

            var terms2 = new List<Term>
            {
                new Term("неуд.", 0, 0, 0.4, 0.5),
                new Term("уд.", 0.4, 0.5, 0.6, 0.7),
                new Term("хор.", 0.6, 0.7, 0.8, 0.9),
                new Term("отл.", 0.8, 0.9, 1, 1)
            };
            var x2 = new LingVariable("X2", terms2);
            result.ProblemConditions.AddVariable(x2);

            var terms3 = new List<Term>
            {
                new Term("низкий", 0, 0, 0.3, 0.4),
                new Term("средний", 0.3, 0.4, 0.7, 0.8),
                new Term("высокий", 0.7, 0.8, 1, 1)
            };
            var y = new LingVariable("Y", terms3);
            result.ProblemConditions.AddVariable(y);
            #endregion

            #region rules
            Rule r1 = Rule.Create("X1=высокий & X2=отл. => Y=высокий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r1);

            Rule r2 = Rule.Create("X1=высокий & X2=хор. => Y=высокий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r2);

            Rule r3 = Rule.Create("X1=высокий & X2=уд. => Y=средний", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r3);

            Rule r4 = Rule.Create("X1=высокий & X2=неуд. => Y=низкий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r4);

            Rule r5 = Rule.Create("X1=средний & X2=отл. => Y=высокий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r5);

            Rule r6 = Rule.Create("X1=средний & X2=хор. => Y=средний", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r6);

            Rule r7 = Rule.Create("X1=средний & X2=уд. => Y=средний", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r7);

            Rule r8 = Rule.Create("X1=средний & X2=неуд. => Y=низкий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r8);

            Rule r9 = Rule.Create("X1=низкий & X2=отл. => Y=средний", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r9);

            Rule r10 = Rule.Create("X1=низкий & X2=хор. => Y=средний", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r10);

            Rule r11 = Rule.Create("X1=низкий & X2=уд. => Y=низкий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r11);

            Rule r12 = Rule.Create("X1=низкий & X2=неуд. => Y=низкий", result.ProblemConditions.Variables);
            result.ProblemConditions.AddRule(r12);

            #endregion

            return result;
        }

        public static ExecutionResult<ProblemConditions> ReadConditionsFromXmlStream(Stream stream)
        {
            try
            {
                var result = ProblemConditionsReader.ReadFromXmlStream(stream);
                if (result != null)
                {
                    return ExecutionResult<ProblemConditions>.Succeded(result);
                }
                return ExecutionResult<ProblemConditions>.Error("Не удалось распознать документ");
            }
            catch (ProblemConditionsParseException e)
            {
                return ExecutionResult<ProblemConditions>.Error(e.Message);
            }
            catch (Exception e)
            {
                return ExecutionResult<ProblemConditions>.Error(e);
            }
        }

        public static ExecutionResult<ProblemConditions> ReadConditionsFromXmlString(string xmlString)
        {
            try
            {
                var result = ProblemConditionsReader.ReadFromXmlString(xmlString);
                if (result != null)
                {
                    return ExecutionResult<ProblemConditions>.Succeded(result);
                }
                return ExecutionResult<ProblemConditions>.Error("Не удалось распознать документ");
            }
            catch (ProblemConditionsParseException e)
            {
                return ExecutionResult<ProblemConditions>.Error(e.Message);
            }
            catch (Exception e)
            {
                return ExecutionResult<ProblemConditions>.Error(e);
            }
        }

        public static void WriteToFile(ProblemConditions conditions, string filePath)
        {
            ProblemConditionsWriter.WriteXmlToFile(conditions, filePath);
        }
    }
}
