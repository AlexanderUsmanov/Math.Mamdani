using FuzzyLogic.Mamdani.Problems;

namespace FuzzyLogic.Mamdani.Interfaces
{
    public interface IMamdaniService
    {
        double SolveProblem(Problem problem);
        double SolveProblem(ProblemConditions conditions, double[] input);
    }
}
