namespace BlazorLanguageLearningApp.Shared;

public class Exercise
{
    public ExerciseType Type { get; set; }
    public ExerciseEntry Question { get; set; }
    public ExerciseEntry? Answer { get; set; }
    public List<ExerciseEntry> PossibleAnswers { get; set; }
    public ExerciseEntry? UserAnswer { get; set; }
    public bool IsSolved() => UserAnswer is not null;

    public Exercise() 
    {
        Question = new();
        Answer = new();
        PossibleAnswers = new();
    }

    public Exercise(ExerciseType type, ExerciseEntry question, ExerciseEntry answer, List<ExerciseEntry> possibleAnswers)
    {
        Type = type;
        Question = question;
        Answer = answer;
        PossibleAnswers = possibleAnswers;
    }
}

public enum ExerciseType { Selection, TrueOrFalse, TypeIn }

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

    public override bool Equals(Object? obj)
    {
        if (obj == null || obj is not ExerciseEntry)
            return false;
        else
            return Expression.ToLowerInvariant() == ((ExerciseEntry)obj).Expression.ToLowerInvariant() 
                   && Language.ToLowerInvariant() == ((ExerciseEntry)obj).Language.ToLowerInvariant();
    }

    public override int GetHashCode()
    {
        return Expression.GetHashCode() + Language.GetHashCode();
    }

}
