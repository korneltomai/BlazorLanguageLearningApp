namespace BlazorLanguageLearningApp.Client.Services;

using BlazorLanguageLearningApp.Shared;
using System.Net.Http.Json;

public class SetService
{
    private readonly HttpClient _httpClient;
    public Set? CurrentSet { get; set; }
    public List<Action> OnChange = new();
    
    public SetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Set?> GetSetById(string username, int folderId, int setId)
    {
        return await _httpClient.GetFromJsonAsync<Set?>($"api/sets/{username}/{folderId}/{setId}");
    }

    public async Task SetCurrentSetById(string username, int folderId, int setId)
    {
        CurrentSet = await _httpClient.GetFromJsonAsync<Set?>($"api/sets/{username}/{folderId}/{setId}");
        NotifyStateChanged();
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

    public void AddCard(Card card)
    {
        if (CurrentSet is null)
            return;

        CurrentSet.Cards.Add(card);

        NotifyStateChanged();
    }

    public void RemoveCard(int cardId)
    {
        if (CurrentSet is null)
            return;

        var cardToDelete = CurrentSet.Cards.Where(c => c.Id == cardId).FirstOrDefault();
        if (cardToDelete is null)
            return;

        CurrentSet.Cards.Remove(cardToDelete);

        NotifyStateChanged();
    }

    public bool CurrentContainsCard(Card card)
    {
        if (CurrentSet is null)
            return false;

        return CurrentSet.Cards.Where(c =>
                card.Term == c.Term 
                && card.Definition == c.Definition
                && card.TermLanguage == c.TermLanguage
                && card.DefinitionLanguage == c.DefinitionLanguage)
            .Any();
    }

    private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
}
