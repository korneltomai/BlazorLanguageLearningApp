using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Server.Helpers;
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

    [HttpGet("{username}/{folderId}/{setId}/new")]
    public async Task<ActionResult<ExerciseSheet>> GetNewExerciseSheet(
        string username, 
        int folderId, 
        int setId, 
        int count, 
        bool generateSelectionExercise, 
        bool generateTrueOrFalseExercise, 
        bool generateTypeInExercise, 
        bool generateDuplicates, 
        bool generateTermSide, 
        bool generateDefinitionSide)
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

        if (!generateDuplicates && count > set.Cards.Count)
            return BadRequest($"Cannot generate exercise sheet with {count} exercises, because the set only contains {set.Cards.Count} cards.");

        var exerciseSheet = CardSelector.GenerateExerciseSheet(
            set.Cards.ToList(),
            count, 
            generateSelectionExercise, 
            generateTrueOrFalseExercise, 
            generateTypeInExercise, 
            generateDuplicates,
            generateTermSide,
            generateDefinitionSide);

        await ExerciseSheetFileHandler.SaveExerciseSheet(username, setId, exerciseSheet);

        return Ok(exerciseSheet);
    }

    [HttpGet("{username}/{folderId}/{setId}")]
    public async Task<ActionResult<ExerciseSheet>> GetExerciseSheetForSet(string username, int folderId, int setId)
    {
        var user = await _context.Users.Include("Folders.Sets").FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            return NotFound($"User {username} does not exist!");

        var folder = user.Folders.FirstOrDefault(f => f.Id == folderId);
        if (folder is null)
            return NotFound("This folder does not exist!");

        var set = folder.Sets.FirstOrDefault(s => s.Id == setId);
        if (set is null)
            return NotFound("This set does not exist!");

        ExerciseSheet? exerciseSheet = await ExerciseSheetFileHandler.GetExerciseSheet(username, setId);

        return Ok(exerciseSheet);
    }

    [HttpDelete("{username}/{folderId}/{setId}")]
    public async Task<ActionResult> RemoveExerciseForSet(string username, int folderId, int setId)
    {
        var user = await _context.Users.Include("Folders.Sets").FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
            return NotFound($"User {username} does not exist!");

        var folder = user.Folders.FirstOrDefault(f => f.Id == folderId);
        if (folder is null)
            return NotFound("This folder does not exist!");

        var set = folder.Sets.FirstOrDefault(s => s.Id == setId);
        if (set is null)
            return NotFound("This set does not exist!");

        ExerciseSheetFileHandler.DeleteExerciseSheet(username, setId);

        return Ok();
    }
}
