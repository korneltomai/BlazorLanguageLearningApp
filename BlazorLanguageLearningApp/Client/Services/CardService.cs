using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCard(Card card, int setId)
        {
            await _httpClient.PostAsJsonAsync($"api/cards/{setId}", card);
        }

        public async Task UpdateCard(Card card)
        {
            await _httpClient.PutAsJsonAsync($"api/cards", card);
        }

        public async Task DeleteCard(int cardId)
        {
            await _httpClient.DeleteAsync($"api/cards/{cardId}");
        }
    }
}
