using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class SetService
    {
        private readonly HttpClient _httpClient;
        public Set? CurrentSet { get; private set; }
        public List<Action> OnChange = new List<Action>();
        
        public SetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetSetById(int setId)
        {
            CurrentSet = await _httpClient.GetFromJsonAsync<Set?>($"api/sets/{setId}");
        }

        public async Task CreateSet(Set set, int folderId)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/sets/{folderId}", set);
            CurrentSet = await response.Content.ReadFromJsonAsync<Set>();
        }

        public async Task UpdateSet(Set set)
        {
            await _httpClient.PutAsJsonAsync($"api/sets", set);

            NotifyStateChanged();
        }

        public async Task DeleteSet(int setId)
        {
            await _httpClient.DeleteAsync($"api/sets/{setId}");
            CurrentSet = null;
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
