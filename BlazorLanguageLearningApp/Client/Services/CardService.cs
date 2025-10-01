using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;
        private readonly SetService _setService;

        public CardService(HttpClient httpClient, SetService setService)
        {
            _httpClient = httpClient;
            _setService = setService;
        }

        public async Task CreateCard(Card card)
        {
            if (_setService.CurrentSet is null)
                return;

            _setService.AddCard(card);
            await _httpClient.PostAsJsonAsync($"api/cards/{_setService.CurrentSet.Id}", card);
        }

        public async Task UpdateCard(Card card)
        {
            await _httpClient.PutAsJsonAsync($"api/cards", card);
        }

        public async Task DeleteCard(int cardId)
        {
            _setService.RemoveCard(cardId);
            await _httpClient.DeleteAsync($"api/cards/{cardId}");
        }
    }
}
