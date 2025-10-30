using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLanguageLearningApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : Controller
{
    private readonly DataContext _context;

    public ExercisesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{username}/{folderId}/{setId}")]
    public async Task<ActionResult<ExerciseSheet>> GetExercises(string username, int folderId, int setId, int count, bool generateSelectionExercise, bool generateTrueOrFalseExercise, bool generateTypeInExercise)
    {
        var user = await _context.Users.Include("Folders.Sets.Cards").FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            return NotFound($"User {username} does not exist!");

        var folder = user.Folders.FirstOrDefault(f => f.Id == folderId);
        if (folder is null)
            return NotFound("This folder does not exist!");

        var set = folder.Sets.FirstOrDefault(s => s.Id == setId);
        if (set is null)
            return NotFound("This set does not exist!");

        Random random = new Random();
        ExerciseSheet exerciseSheet = new();

        for (int i = 0; i < count; i++)
        {
            List<ExerciseType> possibleExerciseTypes = new();
            if (generateSelectionExercise)
                possibleExerciseTypes.Add(ExerciseType.Selection);
            if (generateTrueOrFalseExercise)
                possibleExerciseTypes.Add(ExerciseType.TrueOrFalse);
            if (generateTypeInExercise)
                possibleExerciseTypes.Add(ExerciseType.TypeIn);

            ExerciseType exerciseType = possibleExerciseTypes[random.Next(0, possibleExerciseTypes.Count)];
            Exercise exercise = exerciseType switch
            {
                ExerciseType.Selection => GenerateSelectionExercise(),
                ExerciseType.TrueOrFalse => GenerateTrueOrFalseExercise(),
                ExerciseType.TypeIn => GenerateTypeInExercise(),
                _ => throw new InvalidOperationException("Invalid exercise type.")
            };
            exerciseSheet.Exercises.Add(exercise);
        }

        return Ok(exerciseSheet);
    }

    public Exercise GenerateSelectionExercise()
    {
        return new Exercise(
            ExerciseType.Selection,
            new ExerciseEntry("Capybara", "english"),
            new()
            {
                new ExerciseEntry("Vizidisznó", "magyar"),
                new ExerciseEntry("Egér", "magyar"),
                new ExerciseEntry("Tehén", "magyar"),
                new ExerciseEntry("Ló", "magyar")
            }
        );
    }

    public Exercise GenerateTrueOrFalseExercise()
    {
        return new Exercise(
            ExerciseType.TrueOrFalse,
            new ExerciseEntry("Capybara", "english"),
            new()
                {
                    new ExerciseEntry("Vizidisznó", "magyar"),
                }
        );
    }

    public Exercise GenerateTypeInExercise()
    {
        return new Exercise(
            ExerciseType.TypeIn,
            new ExerciseEntry("Capybara", "english"),
            new()
                {
                    new ExerciseEntry("", "magyar"),
                }
        );
    }
}
