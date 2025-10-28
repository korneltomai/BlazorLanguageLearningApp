namespace BlazorLanguageLearningApp.Shared;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key, StringLength(25, MinimumLength = 5)]
    public string Username { get; set; } = string.Empty;

    [Required, StringLength(25, MinimumLength = 5)]
    public string Nickname { get; set; } = string.Empty;

    public int ExperiencePoints { get; set; } = 0;
    public int Gems { get; set; } = 0;
    public ICollection<Folder> Folders { get; set; } = new List<Folder>();
}
