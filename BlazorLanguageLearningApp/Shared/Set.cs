using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Set
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Folder name is required.")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Folder visibility is required.")]
        public Visibility Visibility { get; set; }
        public string TermsLanguage { get; set; } = "unknown";
        public string DefinitionsLanguage { get; set; } = "unknown";
        public int LearntPercantage { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public Set(int id, string name, string description, int learntPercantage, List<Card> cards)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            TermsLanguage = "english";
            DefinitionsLanguage = "hungarian";
            LearntPercantage = learntPercantage;
            Cards = cards;
        }

        public Set(int id, string name, string description, int learntPercantage)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            TermsLanguage = "english";
            DefinitionsLanguage = "hungarian";
            LearntPercantage = learntPercantage;
        }

        public Set() { }
    }
}
