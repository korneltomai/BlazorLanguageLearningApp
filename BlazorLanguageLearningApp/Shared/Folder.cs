namespace BlazorLanguageLearningApp.Shared
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Folder(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
