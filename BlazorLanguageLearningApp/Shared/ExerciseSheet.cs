namespace BlazorLanguageLearningApp.Shared;

public class ExerciseSheet
{
    public List<Exercise> Exercises { get; set; }

    public ExerciseSheet() 
    {
        Exercises = new List<Exercise>();
    }

    public ExerciseSheet(List<Exercise> exercises)
    {
        Exercises = exercises;
    }
}
