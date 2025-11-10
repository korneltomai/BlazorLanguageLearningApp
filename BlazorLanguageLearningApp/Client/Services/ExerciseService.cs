namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

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

    public async Task<ExerciseSheet?> GenerateExerciseSheet(
        int count, 
        bool generateSelectionExercise, 
        bool generateTrueOrFalseExercise, 
        bool generateTypeInExercise, 
        bool generateDuplicates,
        bool generateTermSide,
        bool generateDefinitionSide)
    {
        return await _httpClient.GetFromJsonAsync<ExerciseSheet>(
            $"api/exercises/{_userService.CurrentUser!.Username}/{_folderService.CurrentFolder!.Id}/{_setService.CurrentSet!.Id}/new" +
            $"?count={count}" +
            $"&generateSelectionExercise={generateSelectionExercise}" +
            $"&generateTrueOrFalseExercise={generateTrueOrFalseExercise}" +
            $"&generateTypeInExercise={generateTypeInExercise}" +
            $"&generateDuplicates={generateDuplicates}" +
            $"&generateTermSide={generateTermSide}" +
            $"&generateDefinitionSide={generateDefinitionSide}");
    }

    public async Task<ExerciseSheet?> GetExerciseSheetForSet() 
    {
        var response = await _httpClient.GetAsync($"api/exercises/{_userService.CurrentUser!.Username}/{_folderService.CurrentFolder!.Id}/{_setService.CurrentSet!.Id}");
        var content = await response.Content.ReadAsStringAsync();
        return string.IsNullOrEmpty(content) ? null : JsonSerializer.Deserialize<ExerciseSheet>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<SheetValidationResult> ValidateExerciseSheet(ExerciseSheet exerciseSheet)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/exercises/{_userService.CurrentUser!.Username}/{_folderService.CurrentFolder!.Id}/{_setService.CurrentSet!.Id}", exerciseSheet.Exercises.Select(e => e.UserAnswer).ToList());
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SheetValidationResult>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (result is null)
            throw new InvalidOperationException("Invalid validation data!");
        return result;
    }

    public async Task DeleteExerciseSheet()
    {
        await _httpClient.DeleteAsync($"api/exercises/{_userService.CurrentUser!.Username}/{_folderService.CurrentFolder!.Id}/{_setService.CurrentSet!.Id}");
    }

    
}

