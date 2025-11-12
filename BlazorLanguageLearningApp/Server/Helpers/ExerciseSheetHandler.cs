using BlazorBootstrap;
using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlazorLanguageLearningApp.Server.Helpers;

public static class ExerciseSheetHandler
{
    private const string EXERCISE_SHEETS_BASEPATH = @"\sitedata\sheets";

    private static string GetPathForExerciseSheet(string username, int setId) => Path.Combine(Directory.GetCurrentDirectory(), EXERCISE_SHEETS_BASEPATH, username, $"{setId}.json");

    public async static Task<ExerciseSheet?> GetExerciseSheet(string username, int setId)
    {
        string filePath = GetPathForExerciseSheet(username, setId);
        if (!File.Exists(filePath))
            return null;
        string jsonString = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<ExerciseSheet>(jsonString);
    }

    public async static Task SaveExerciseSheet(string username, int setId, ExerciseSheet exerciseSheet)
    {
        string filePath = GetPathForExerciseSheet(username, setId);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        string jsonString = JsonSerializer.Serialize(exerciseSheet, new JsonSerializerOptions() { WriteIndented = true });
        await File.WriteAllTextAsync(GetPathForExerciseSheet(username, setId), jsonString);
    }

    public static void DeleteExerciseSheet(string username, int setId)
    {
        string filePath = GetPathForExerciseSheet(username, setId);
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    public async static Task<SheetValidationResult> ValidateExerciseSheet(string username, int setId, ExerciseSheet exerciseSheet, List<ExerciseEntry> userAnswers)
    {
        for (int i = 0; i < exerciseSheet.Exercises.Count; i++)
            exerciseSheet.Exercises[i].UserAnswer = userAnswers[i];

        exerciseSheet.Solved = true;
        await SaveExerciseSheet(username, setId, exerciseSheet);

        List<ExerciseEntry> answers = exerciseSheet.Exercises.Select(e => e.Answer).ToList()!;
        int expGained = exerciseSheet.GetExpReward();
        int gemsGained = exerciseSheet.GetGemReward();

        return new SheetValidationResult(answers, expGained, gemsGained);
    }
}
