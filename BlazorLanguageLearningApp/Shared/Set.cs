using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Set
    {
        [Required(ErrorMessage = "Folder name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Folder visibility is required.")]
        public Visibility Visibility { get; set; }

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string TermsLanguage { get; set; } = "unknown";
        public string DefinitionsLanguage { get; set; } = "unknown";
        public int LearntPercantage => Cards.Sum(c => c.LearntPercantage) / Cards.Count;
        public List<Card> Cards { get; set; } = new List<Card>();

        public Set(int id, string name, string description, List<Card> cards)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            TermsLanguage = "english";
            DefinitionsLanguage = "hungarian";
            Cards = cards;
        }

        public Set() { }
    }
}
