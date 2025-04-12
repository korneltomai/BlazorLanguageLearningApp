using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorLanguageLearningApp.Client.Services
{
    public class CardService
    {
        private readonly SetService _setService;
        public List<Action> OnChange = new List<Action>();

        public CardService(SetService setService)
        {
            _setService = setService;
        }

        public void AddCard(Card card)
        {
            _setService.CurrentSet!.Cards.Add(card);
            NotifyStateChanged();
        }

        public void RemoveCard(Card card)
        {
            _setService.CurrentSet!.Cards.Remove(card);
            NotifyStateChanged();
        }

        public void UpdateCard(Card card)
        {
            Card oldCard = _setService.CurrentSet!.Cards.FirstOrDefault(c => c.Id == card.Id)!;
            oldCard = card;
            NotifyStateChanged();
        }

        public Card? GetCard(int cardId)
        {
            return _setService.CurrentSet!.Cards.FirstOrDefault(c => c.Id == cardId);
        }

        private void NotifyStateChanged() => OnChange.ForEach(a => a.Invoke());
    }
}
