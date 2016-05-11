using System.Collections.Generic;
using FuzzyLogic.Mamdani.Statements;

namespace FuzzyLogic.Mamdani.Problems
{
    public static class ProblemSamples
    {
        //public static Problem First()
        //{
        //    var result = new Problem
        //    {
        //        InputData = new[] {0.7, 0.83},
        //        ProblemConditions = new ProblemConditions()
        //    };

        //    #region variables
        //    var terms1 = new List<Term>
        //    {
        //        new Term("низкий", 0, 0, 0.3, 0.4),
        //        new Term("средний", 0.3, 0.4, 0.6, 0.7),
        //        new Term("высокий", 0.6, 0.7, 1, 1)
        //    };
        //    var x1 = new LingVariable("input1", terms1);
        //    result.ProblemConditions.AddVariable("X1", x1);

        //    var terms2 = new List<Term>
        //    {
        //        new Term("неуд.", 0, 0, 0.4, 0.5),
        //        new Term("уд.", 0.4, 0.5, 0.6, 0.7),
        //        new Term("хор.", 0.6, 0.7, 0.8, 0.9),
        //        new Term("отл.", 0.8, 0.9, 1, 1)
        //    };
        //    var x2 = new LingVariable("input2", terms2);
        //    result.ProblemConditions.AddVariable("X2", x2);

        //    var terms3 = new List<Term>
        //    {
        //        new Term("низкий", 0, 0, 0.3, 0.4),
        //        new Term("средний", 0.3, 0.4, 0.7, 0.8),
        //        new Term("высокий", 0.7, 0.8, 1, 1)
        //    };
        //    var y = new LingVariable("output", terms3);
        //    result.ProblemConditions.AddVariable("Y", y);
        //    #endregion

        //    #region rules
        //    Rule r1 = new Rule();
        //    r1.SetConditions(new Condition("X1", "высокий"), new Condition("X2", "отл."));
        //    r1.SetConclusion(new Conclusion("Y", "высокий"));
        //    result.ProblemConditions.AddRule(r1);

        //    Rule r2 = new Rule();
        //    r2.SetConditions(new Condition("X1", "высокий"), new Condition("X2", "хор."));
        //    r2.SetConclusion(new Conclusion("Y", "высокий"));
        //    result.ProblemConditions.AddRule(r2);

        //    Rule r3 = new Rule();
        //    r3.SetConditions(new Condition("X1", "высокий"), new Condition("X2", "уд."));
        //    r3.SetConclusion(new Conclusion("Y", "средний"));
        //    result.ProblemConditions.AddRule(r3);

        //    Rule r4 = new Rule();
        //    r4.SetConditions(new Condition("X1", "высокий"), new Condition("X2", "неуд."));
        //    r4.SetConclusion(new Conclusion("Y", "низкий"));
        //    result.ProblemConditions.AddRule(r4);

        //    Rule r5 = new Rule();
        //    r5.SetConditions(new Condition("X1", "средний"), new Condition("X2", "отл."));
        //    r5.SetConclusion(new Conclusion("Y", "высокий"));
        //    result.ProblemConditions.AddRule(r5);

        //    Rule r6 = new Rule();
        //    r6.SetConditions(new Condition("X1", "средний"), new Condition("X2", "хор."));
        //    r6.SetConclusion(new Conclusion("Y", "средний"));
        //    result.ProblemConditions.AddRule(r6);

        //    Rule r7 = new Rule();
        //    r7.SetConditions(new Condition("X1", "средний"), new Condition("X2", "уд."));
        //    r7.SetConclusion(new Conclusion("Y", "средний"));
        //    result.ProblemConditions.AddRule(r7);

        //    Rule r8 = new Rule();
        //    r8.SetConditions(new Condition("X1", "средний"), new Condition("X2", "неуд."));
        //    r8.SetConclusion(new Conclusion("Y", "низкий"));
        //    result.ProblemConditions.AddRule(r8);

        //    Rule r9 = new Rule();
        //    r9.SetConditions(new Condition("X1", "низкий"), new Condition("X2", "отл."));
        //    r9.SetConclusion(new Conclusion("Y", "средний"));
        //    result.ProblemConditions.AddRule(r9);

        //    Rule r10 = new Rule();
        //    r10.SetConditions(new Condition("X1", "низкий"), new Condition("X2", "хор."));
        //    r10.SetConclusion(new Conclusion("Y", "средний"));
        //    result.ProblemConditions.AddRule(r10);

        //    Rule r11 = new Rule();
        //    r11.SetConditions(new Condition("X1", "низкий"), new Condition("X2", "уд."));
        //    r11.SetConclusion(new Conclusion("Y", "низкий"));
        //    result.ProblemConditions.AddRule(r11);

        //    Rule r12 = new Rule();
        //    r12.SetConditions(new Condition("X1", "низкий"), new Condition("X2", "неуд."));
        //    r12.SetConclusion(new Conclusion("Y", "низкий"));
        //    result.ProblemConditions.AddRule(r12);

        //    #endregion

        //    return result;
        //}
    }
}
