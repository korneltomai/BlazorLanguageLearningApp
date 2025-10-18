namespace BlazorLanguageLearningApp.Shared;

public class Exercise
{
    public ExerciseType Type { get; set; }
    public ExerciseEntry Question { get; set; }
    public List<ExerciseEntry> PossibleAnswers { get; set; }
    public ExerciseEntry UserAnswer { get; set; } = new();

    public Exercise(ExerciseType type, ExerciseEntry question, List<ExerciseEntry> possibleAnswers)
    {
        Type = type;
        Question = question;
        PossibleAnswers = possibleAnswers;
    }
}

public enum ExerciseType { TrueOrFalse, Selection, TypeIn }

public class ExerciseEntry 
{
    public string Expression { get; set; }
    public string Language { get; set; }

    public ExerciseEntry()
    {
        Expression = "";
        Language = "";
    }

    public ExerciseEntry(string expression, string language)
    {
        Expression = expression;
        Language = language;
    }
}
