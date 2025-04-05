namespace BlazorLanguageLearningApp.Shared
{
    public class Card
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string TermLanguage { get; set; }
        public string DefinitionLanguage { get; set; }
        public int LearntPercantage { get; set; }

        public Card(int id, string term, string definition, string termLanguage, string definitionLanguage, int learntPercantage)
        {
            Id = id;
            Term = term;
            Definition = definition;
            TermLanguage = termLanguage;
            DefinitionLanguage = definitionLanguage;
            LearntPercantage = learntPercantage;
        }
    }
}
