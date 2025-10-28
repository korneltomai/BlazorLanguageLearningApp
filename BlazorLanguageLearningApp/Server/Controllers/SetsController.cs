using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLanguageLearningApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : Controller
    {
        private readonly DataContext _context;

        public SetsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{username}/{folderId}/{setId}")]
        public async Task<ActionResult<Set>> GetSetById(string username, int folderId, int setId)
        {
            var user = await _context.Users.Include("Folders.Sets.Cards.PastAnswers").FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return NotFound($"User {username} does not exist!");

            var folder = user.Folders.FirstOrDefault(f => f.Id == folderId);
            if (folder is null)
                return NotFound("This folder does not exist!");

            var set = folder.Sets.FirstOrDefault(s => s.Id == setId);
            if (set is null)
                return NotFound("This set does not exist!");

            CalculateCardScores(set);
            await _context.SaveChangesAsync();

            return Ok(set);
        }

        [HttpPost("{folderId}")]
        public async Task<ActionResult<Set>> CreateSet(int folderId, Set set)
        {
            var folder = await _context.Folders.FindAsync(folderId);
            if (folder is null)
                return NotFound("This folder does not exist!");
            folder.Sets.Add(set);

            _context.Sets.Add(set);

            await _context.SaveChangesAsync();

            return Ok(set);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSet(Set set)
        {
            var dbSet = await _context.Sets.FindAsync(set.Id);
            if (dbSet is null)
                return NotFound("This set does not exist!");

            _context.Entry(dbSet).CurrentValues.SetValues(set);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{setId}")]
        public async Task<ActionResult> DeleteSet(int setId)
        {
            var dbSet = await _context.Sets.FindAsync(setId);
            if (dbSet is null)
                return NotFound("This set does not exist!");

            _context.Sets.Remove(dbSet);

            await _context.SaveChangesAsync();

            return Ok();
        }

        private static void CalculateCardScores(Set set)
        {
            foreach (var card in set.Cards)
            {
                if (card.PastAnswers.Count == 0)
                    card.LearntPercantage = 0;
                else
                    card.LearntPercantage = (int)((double)card.PastAnswers.Count(a => a.Correct) / card.PastAnswers.Count * 100);
            }
        }
    }
}
