namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

public class ExerciseService
{
    private readonly HttpClient _httpClient;
    private readonly UserService _userService;
    private readonly FolderService _folderService;
    private readonly SetService _setService;

    public ExerciseService(HttpClient httpClient, UserService userService, FolderService folderService, SetService setService)
    {
        _httpClient = httpClient;
        _userService = userService;
        _folderService = folderService;
        _setService = setService;
    }

    public async Task<ExerciseSheet?> GenerateExerciseSheet(int count, bool generateSelectionExercise, bool generateTrueOrFalseExercise, bool generateTypeInExercise)
    {
        return await _httpClient.GetFromJsonAsync<ExerciseSheet>($"api/exercises/{_userService.CurrentUser!.Username}/{_folderService.CurrentFolder!.Id}/{_setService.CurrentSet!.Id}/?count={count}&generateSelectionExercise={generateSelectionExercise}&generateTrueOrFalseExercise={generateTrueOrFalseExercise}&generateTypeInExercise={generateTypeInExercise}");
    }
}

