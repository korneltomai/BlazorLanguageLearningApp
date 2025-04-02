namespace BlazorLanguageLearningApp.Shared
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }
        public List<Set> Sets { get; set; }

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
            Sets = new List<Set>();
        }
    }
}
