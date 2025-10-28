namespace BlazorLanguageLearningApp.Shared;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string TermsLanguage { get; set; } = string.Empty;
    public string DefinitionsLanguage { get; set; } = string.Empty;
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public int LearntPercantage { get; set; }
}
