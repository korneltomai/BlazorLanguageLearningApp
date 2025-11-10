using System.Reflection.Metadata.Ecma335;

namespace BlazorLanguageLearningApp.Shared;

public class ExerciseSheet
{
    public List<Exercise> Exercises { get; set; }
    public SheetValidationResult? ValidationResult { get; set; }
    public bool Solved { get; set; }

    public int GetCorrectExerciseCount()
    {
        if (Exercises.Any(e => e.Answer is null || e.UserAnswer is null))
            throw new InvalidOperationException("Cannot count correct exercises for an incomplete exercise sheet!");
        return Exercises.Count(e => e.IsCorrect());
    }

    public int GetCorrectExercisePercentage() => (int)((double)GetCorrectExerciseCount() / Exercises.Count * 100);

    public int GetExpReward()
    {
        int exp = Exercises.Sum(e => e.GetExpReward());
        if (Exercises.Count >= 10)
            return (int)(exp * ((double)Exercises.Count / 100 + 1));
        return exp;
    }

    public int GetGemReward()
    {
        Random random = new();
        double randomChance = random.NextDouble() * 100;

        if (Exercises.Count == 1)
        {
            if (GetCorrectExercisePercentage() == 100 && randomChance >= 98)
                return 1;
            return 0;
        }

        int gemCount = 0;
        for (int exerciseCount = Exercises.Count; exerciseCount >= 10; exerciseCount -= 10)
        {
            if (randomChance >= GetGemProbability())
                gemCount++;
        }

        return gemCount;
    }

    private double GetGemProbability() 
    {
        if (GetCorrectExercisePercentage() < 75)
            return 0;

        var sum = 0.0;
        for (int i = 0; i <= 100; i++)
            sum += Math.Exp(0.1 * i);

        return GetCorrectExercisePercentage() / sum * 100 * ((double)(Exercises.Count - 10) / 100 + 1);
    } 

    public ExerciseSheet() 
    {
        Exercises = new List<Exercise>();
    }

    public ExerciseSheet(List<Exercise> exercises)
    {
        Exercises = exercises;
    }
}

public class SheetValidationResult
{
    public List<ExerciseEntry> Answers { get; set; } = new();
    public int ExpGained { get; set; }
    public int GemsGained { get; set; }

    public SheetValidationResult(List<ExerciseEntry> answers, int expGained, int gemsGained)
    {
        Answers = answers;
        ExpGained = expGained;
        GemsGained = gemsGained;
    }
}
