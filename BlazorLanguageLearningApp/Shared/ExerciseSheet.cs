namespace BlazorLanguageLearningApp.Shared;

public class ExerciseSheet
{
    public List<Exercise> Exercises { get; set; }
    public bool Solved { get; set; }

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
