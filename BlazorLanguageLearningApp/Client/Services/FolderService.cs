namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

public class FolderService
{
    private readonly HttpClient _httpClient;

    public Folder? CurrentFolder { get; set; }

    public List<Action> OnChange = new List<Action>();

    public FolderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SetFolderById(string username, int folderId)
    {
        CurrentFolder = await _httpClient.GetFromJsonAsync<Folder?>($"api/folders/{username}/{folderId}");
    }

    public async Task<List<Folder>?> GetAllFoldersForUser(string username)
    {
        return await _httpClient.GetFromJsonAsync<List<Folder>>($"api/folders/{username}/all");
    }

    public async Task CreateFolder(string username, Folder folder)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/folders/{username}", folder);
        CurrentFolder = await response.Content.ReadFromJsonAsync<Folder>();
    }

    public async Task UpdateFolder(Folder folder)
    {
        await _httpClient.PutAsJsonAsync($"api/folders", folder);

        NotifyStateChanged();
    }

    public async Task DeleteFolder(int folderId)
    {
        await _httpClient.DeleteAsync($"api/folders/{folderId}");
        CurrentFolder = null;
    }

    private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
}
