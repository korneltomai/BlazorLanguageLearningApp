using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace BlazorLanguageLearningApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly DataContext _context;

        public FoldersController(DataContext context) 
        { 
            _context = context; 
        }

        [HttpGet("{username}/all")]
        public async Task<ActionResult<List<Folder>>> GetAllFoldersForUser(string username)
        {
            var user = await _context.Users.Include("Folders.Sets").FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return NotFound($"User {username} does not exist!");
            return Ok(user.Folders);
        }

        [HttpGet("{username}/{folderId}")]
        public async Task<ActionResult<Folder>> GetFolderById(string username, int folderId)
        {
            var user = await _context.Users.Include("Folders.Sets").FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return NotFound($"User {username} does not exist!");

            var folder = user.Folders.FirstOrDefault(f => f.Id == folderId);
            if (folder is null)
                return NotFound("This folder does not exist!");

            return Ok(folder);
        }

        [HttpPost("{username}")]
        public async Task<ActionResult<Set>> CreateFolder(string username, Folder folder)
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null)
                return NotFound($"User {username} does not exist!");

            user.Folders.Add(folder);
            _context.Folders.Add(folder);

            await _context.SaveChangesAsync();

            return Ok(folder);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFolder(Folder folder)
        {
            var dbFolder = await _context.Folders.FindAsync(folder.Id);
            if (dbFolder is null)
                return NotFound("This folder does not exist!");

            _context.Entry(dbFolder).CurrentValues.SetValues(folder);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{folderId}")]
        public async Task<ActionResult> DeleteFolder(int folderId)
        {
            var dbFolder = await _context.Folders.FindAsync(folderId);
            if (dbFolder is null)
                return NotFound("This folder does not exist!");

            _context.Folders.Remove(dbFolder);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
