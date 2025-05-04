using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Set
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Folder name is required.")]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Folder visibility is required.")]
        public Visibility Visibility { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public string TermsLanguage { get; set; } = "unkown";
        public string DefinitionsLanguage { get; set; } = "unkown"; 
        public int LearntPercantage { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
