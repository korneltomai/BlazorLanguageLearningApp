namespace BlazorLanguageLearningApp.Shared;

public class AnswerRecord
{
    public int Id { get; set; }
    public bool Correct { get; set; }
    public DateTime Created { get; set; }

    public AnswerRecord() { }

    public AnswerRecord(bool correct) 
    {
        Correct = correct;
    }
}
