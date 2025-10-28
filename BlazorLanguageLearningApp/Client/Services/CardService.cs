namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

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

        var response = await _httpClient.PostAsJsonAsync($"api/cards/{_setService.CurrentSet.Id}", card);
        var newCard = await response.Content.ReadFromJsonAsync<Card>();
        if (newCard is not null)
            _setService.AddCard(newCard); 
    }

    public async Task CopyCard(Card card)
    {
        var copyCard = new Card() 
        { 
            Term = card.Term, 
            Definition = card.Definition, 
            TermLanguage = card.TermLanguage, 
            DefinitionLanguage = card.DefinitionLanguage,
            LearntPercantage = card.LearntPercantage
        };

        await CreateCard(copyCard);
    }

    public async Task UpdateCard(Card card)
    {
        await _httpClient.PutAsJsonAsync($"api/cards", card);
    }

    public async Task DeleteCard(int cardId)
    {
        if (_setService.CurrentSet is null)
            return;

        _setService.RemoveCard(cardId);
        await _httpClient.DeleteAsync($"api/cards/{_setService.CurrentSet.Id}/{cardId}");
    }
}
