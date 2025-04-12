using System.ComponentModel.DataAnnotations;

namespace BlazorLanguageLearningApp.Shared
{
    public class Folder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Folder name is required.")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Visibility is required.")]
        public Visibility Visibility { get; set; }
        public List<Set> Sets { get; set; } = new List<Set>();

        public Folder(int id, string name, string description, List<Set> sets)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            Sets = sets;
        }

        public Folder(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
        }

        public Folder(string name, string description, Visibility visibility)
        {
            Name = name;
            Description = description;
            Visibility = visibility;
        }

        public Folder() { }
    }
}
