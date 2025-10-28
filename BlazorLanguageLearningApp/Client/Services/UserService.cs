namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

public class UserService
{
    private readonly HttpClient _httpClient;

    public User? AuthenticatedUser { get; set; }
    public User? CurrentUser { get; set; }

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SetAuthenticatedUser(string username)
    {
        AuthenticatedUser = await _httpClient.GetFromJsonAsync<User?>($"api/users/{username}");
    }

    public async Task SetCurrentUser(string username)
    {
        CurrentUser = await _httpClient.GetFromJsonAsync<User?>($"api/users/{username}");
    }
}
