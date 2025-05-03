using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Card
    {
        [Required(ErrorMessage = "Term is required.")]
        public string Term { get; set; } = string.Empty;

        [Required(ErrorMessage = "Definition is required.")]
        public string Definition { get; set; } = string.Empty;

        public int Id { get; set; }
        public string TermLanguage { get; set; } = "unknown";
        public string DefinitionLanguage { get; set; } = "unknown";
        public int LearntPercantage { get; set; }

        public Card(int id, string term, string definition, string termLanguage, string definitionLanguage, int learntPercantage)
        {
            Id = id;
            Term = term;
            Definition = definition;
            TermLanguage = termLanguage;
            DefinitionLanguage = definitionLanguage;
            LearntPercantage = learntPercantage;
        }

        public Card() { }
    }
}
