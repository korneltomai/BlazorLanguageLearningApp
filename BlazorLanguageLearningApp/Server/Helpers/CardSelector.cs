namespace BlazorLanguageLearningApp.Server.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using BlazorLanguageLearningApp.Shared;

public static class CardSelector
{
    public static ExerciseSheet GenerateExerciseSheet(
        List<Card> cards, 
        int count, 
        bool generateSelectionExercise, 
        bool generateTrueOrFalseExercise, 
        bool generateTypeInExercise, 
        bool generateDuplicates,
        bool generateTermSide,
        bool generateDefinitionSide)
    {
        var randomCards = GetRandomCards(cards, count, generateDuplicates);

        List<ExerciseType> possibleExerciseTypes = new();
        if (generateSelectionExercise)
            possibleExerciseTypes.Add(ExerciseType.Selection);
        if (generateTrueOrFalseExercise)
            possibleExerciseTypes.Add(ExerciseType.TrueOrFalse);
        if (generateTypeInExercise)
            possibleExerciseTypes.Add(ExerciseType.TypeIn);

        Random random = new Random();
        ExerciseSheet exerciseSheet = new();

        for (int i = 0; i < randomCards.Count; i++)
        {
            ExerciseType exerciseType = possibleExerciseTypes[random.Next(0, possibleExerciseTypes.Count)];
            Exercise exercise = exerciseType switch
            {
                ExerciseType.Selection => GenerateSelectionExercise(cards, randomCards[i], generateTermSide, generateDefinitionSide),
                ExerciseType.TrueOrFalse => GenerateTrueOrFalseExercise(cards, randomCards[i], generateTermSide, generateDefinitionSide),
                ExerciseType.TypeIn => GenerateTypeInExercise(randomCards[i], generateTermSide, generateDefinitionSide),
                _ => throw new InvalidOperationException("Invalid exercise type.")
            };
            exerciseSheet.Exercises.Add(exercise);
        }

        return exerciseSheet;
    }

    private static double GetWeight(Card card) => Math.Exp(-0.05 * card.LearntPercantage);

    private static List<Card> GetRandomCards(List<Card> cards, int count, bool generateDuplicates)
    {
        if (cards == null || cards.Count == 0)
            return new List<Card>();

        var remainingCards = new List<Card>(cards);
        var selectedCards = new List<Card>();

        var weights = remainingCards.Select(GetWeight).ToList();
        double totalWeight = weights.Sum();
        var normalizedWeights = weights.Select(w => w / totalWeight).ToList();

        var random = new Random();

        for (int i = 0; i < count; i++)
        {
            double r = random.NextDouble();
            double cumulative = 0.0;
            int chosenIndex = 0;

            for (int j = 0; j < remainingCards.Count; j++)
            {
                cumulative += normalizedWeights[j];
                if (r <= cumulative)
                {
                    chosenIndex = j;
                    break;
                }
            }

            selectedCards.Add(remainingCards[chosenIndex]);

            if (!generateDuplicates)
            {
                remainingCards.RemoveAt(chosenIndex);
                weights = remainingCards.Select(GetWeight).ToList();
                totalWeight = weights.Sum();
                normalizedWeights = weights.Select(w => w / totalWeight).ToList();
            }
        }

        return selectedCards;
    }

    private static Exercise GenerateSelectionExercise(List<Card> cards, Card card, bool generateTermSide, bool generateDefinitionSide)
    {
        var askedCardSide = GetAskedCardSide(card, generateTermSide, generateDefinitionSide);
        (ExerciseEntry answerSide, ExerciseEntry askedSide) = GetCardSides(card, askedCardSide);
        List<ExerciseEntry> possibleAnswers = new() { answerSide };

        var possibleFalseAnswerCards = new List<Card>(cards);
        possibleFalseAnswerCards.Remove(card);
        var falseAnswerCards = GetRandomCards(possibleFalseAnswerCards, 3, false);

        foreach (var falseAnswerCard in falseAnswerCards)
        {
            var answerCardSide = askedCardSide == CardSide.DefinitionSide ? CardSide.DefinitionSide : CardSide.TermSide;
            (ExerciseEntry cardSide, _) = GetCardSides(falseAnswerCard, answerCardSide);
            possibleAnswers.Add(cardSide);
        }

        Random random = new();
        possibleAnswers = possibleAnswers.OrderBy(_ => random.Next()).ToList();

        return new Exercise(
            ExerciseType.Selection,
            askedSide,
            answerSide,
            possibleAnswers
        );
    }

    private static Exercise GenerateTrueOrFalseExercise(List<Card> cards, Card card, bool generateTermSide, bool generateDefinitionSide)
    {
        var askedCardSide = GetAskedCardSide(card, generateTermSide, generateDefinitionSide);
        (ExerciseEntry answerSide, ExerciseEntry askedSide) = GetCardSides(card, askedCardSide);

        List<ExerciseEntry> possibleAnswers = new();

        Random random = new Random();
        var r = random.Next(2);
        if (r < 1)
            possibleAnswers.Add(answerSide);
        else
        {
            var possibleFalseAnswerCards = new List<Card>(cards);
            possibleFalseAnswerCards.Remove(card);
            var falseAnswerCards = GetRandomCards(possibleFalseAnswerCards, 1, false);

            foreach (var falseAnswerCard in falseAnswerCards)
            {
                var answerCardSide = askedCardSide == CardSide.DefinitionSide ? CardSide.DefinitionSide : CardSide.TermSide;
                (ExerciseEntry cardSide, _) = GetCardSides(falseAnswerCard, answerCardSide);
                possibleAnswers.Add(cardSide);
            }
        }

        return new Exercise(
            ExerciseType.TrueOrFalse,
            askedSide,
            answerSide,
            possibleAnswers
        );
    }

    private static Exercise GenerateTypeInExercise(Card card, bool generateTermSide, bool generateDefinitionSide)
    {
        var askedCardSide = GetAskedCardSide(card, generateTermSide, generateDefinitionSide);
        (ExerciseEntry answerSide, ExerciseEntry askedSide) = GetCardSides(card, askedCardSide);

        return new Exercise(
            ExerciseType.TypeIn,
            askedSide,
            answerSide,
            new()
                {
                    new ExerciseEntry("", answerSide.Language),
                }
        );
    }

    private static CardSide GetAskedCardSide(Card card, bool generateTermSide, bool generateDefinitionSide)
    {
        if (generateTermSide && generateDefinitionSide)
        {
            Random random = new Random();
            var r = random.Next(2);
            if (r < 1)
                return CardSide.TermSide;
            else
                return CardSide.DefinitionSide;
        }
        else if (generateDefinitionSide)
            return CardSide.DefinitionSide;
        else
            return CardSide.TermSide;
    }

    private static (ExerciseEntry, ExerciseEntry) GetCardSides(Card card, CardSide askedCardSide)
    {
        if (askedCardSide == CardSide.DefinitionSide)
            return (new ExerciseEntry(card.Definition, card.DefinitionLanguage), new ExerciseEntry(card.Term, card.TermLanguage));
        else
            return (new ExerciseEntry(card.Term, card.TermLanguage), new ExerciseEntry(card.Definition, card.DefinitionLanguage));
    }

    private enum CardSide { TermSide, DefinitionSide }
}
