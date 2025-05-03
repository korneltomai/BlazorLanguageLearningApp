using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Folder
    {
        [Required(ErrorMessage = "Folder name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Visibility is required.")]
        public Visibility Visibility { get; set; }

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Set> Sets { get; set; } = new List<Set>();

        public Folder(int id, string name, string description, List<Set> sets)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            Sets = sets;
        }

        public Folder() { }
    }
}
