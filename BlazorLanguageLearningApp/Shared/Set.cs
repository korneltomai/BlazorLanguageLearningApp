namespace BlazorLanguageLearningApp.Shared
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }
        public string TermsLanguage { get; set; }
        public string DefinitionsLanguage { get; set; }
        public int LearntPercantage { get; set; }

        public Set(int id, string name, string description, int learntPercantage)
        {
            Id = id;
            Name = name;
            Description = description;
            Visibility = Visibility.Private;
            TermsLanguage = "english";
            DefinitionsLanguage = "hungarian";
            LearntPercantage = learntPercantage;
        }
    }
}
