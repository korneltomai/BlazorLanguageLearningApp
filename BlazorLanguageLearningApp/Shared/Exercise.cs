namespace BlazorLanguageLearningApp.Shared;

public class Exercise
{
    public ExerciseType Type { get; set; }
    public int QuestionId { get; set; }
    public ExerciseEntry Question { get; set; }
    public ExerciseEntry? Answer { get; set; }
    public List<ExerciseEntry> PossibleAnswers { get; set; }
    public ExerciseEntry? UserAnswer { get; set; }
    
    public Exercise() 
    {
        Question = new();
        Answer = new();
        PossibleAnswers = new();
    }

    public Exercise(ExerciseType type, int questionId, ExerciseEntry question, ExerciseEntry answer, List<ExerciseEntry> possibleAnswers)
    {
        Type = type;
        QuestionId = questionId;
        Question = question;
        Answer = answer;
        PossibleAnswers = possibleAnswers;
    }

    public bool IsSolved() => UserAnswer is not null;
    public bool IsCorrect() 
    {
        if (!IsSolved())
            throw new InvalidOperationException("Cannot check if unnsolved excercise is correct or not.");

        if (Type == ExerciseType.TrueOrFalse)
        {
            if (Answer!.Equals(PossibleAnswers[0]) && UserAnswer!.Equals(new ExerciseEntry("TRUE", "TRUE")))
                return true;
            else if (!Answer!.Equals(PossibleAnswers[0]) && UserAnswer!.Equals(new ExerciseEntry("FALSE", "FALSE")))
                return true;
            else
                return false;
        }
        else
            return Answer!.Equals(UserAnswer);
    }

    public int GetExpReward()
    {
        if (!IsSolved())
            throw new InvalidOperationException("Cannot get exp reward for unnsolved excercise.");

        int exp = Type switch
        {
            ExerciseType.TrueOrFalse => 1,
            ExerciseType.Selection => 2,
            ExerciseType.TypeIn => 3,
            _ => 0
        };

        return IsCorrect() ? exp * 2 : exp;
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
