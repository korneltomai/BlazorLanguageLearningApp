namespace BlazorLanguageLearningApp.Shared;

using System.ComponentModel.DataAnnotations;

public class Folder
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Folder name is required.")]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Visibility is required.")]
    public Visibility Visibility { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Set> Sets { get; set; } = new List<Set>();
}
