using CsvHelper.Configuration;
using BlazorLanguageLearningApp.Shared;
using System.Runtime.CompilerServices;

namespace BlazorLanguageLearningApp.Client.Helpers;

public class CardMap : ClassMap<Card>
{
    public CardMap(int termIndex, int definitionIndex, int termLanguageIndex = -1, int definitionLanguageIndex = -1)
    {
        Map(m => m.Term).Index(termIndex);
        Map(m => m.Definition).Index(definitionIndex);

        if (termLanguageIndex != -1)
            Map(m => m.TermLanguage).Index(termLanguageIndex);
        if (definitionLanguageIndex != -1)
            Map(m => m.DefinitionLanguage).Index(definitionLanguageIndex);
    }
}