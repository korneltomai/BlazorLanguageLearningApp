using CsvHelper.Configuration;
using BlazorLanguageLearningApp.Shared;

namespace BlazorLanguageLearningApp.Client.Helpers;

public class CardMap : ClassMap<Card>
{
    public CardMap(int termLanguageIndex = 0, int definitionLanguageIndex = 1, int termIndex = 2, int definitionIndex = 3)
    {
        Map(m => m.TermLanguage).Index(termLanguageIndex);
        Map(m => m.DefinitionLanguage).Index(definitionLanguageIndex);
        Map(m => m.Term).Index(termIndex);
        Map(m => m.Definition).Index(definitionIndex);
    }
}