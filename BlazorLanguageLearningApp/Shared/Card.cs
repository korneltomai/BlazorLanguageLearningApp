using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Card
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Term is required.")]
        [StringLength(50)]
        public string Term { get; set; } = string.Empty;

        [Required(ErrorMessage = "Definition is required.")]

        [StringLength(50)]
        public string Definition { get; set; } = string.Empty;

        [StringLength(25, MinimumLength = 3)]
        public string TermLanguage { get; set; } = "unknown";

        [StringLength(25, MinimumLength = 3)]
        public string DefinitionLanguage { get; set; } = "unknown";

        public int LearntPercantage { get; set; }
    }
}
