using BlazorLanguageLearningApp.Server.Data;
using BlazorLanguageLearningApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var folders = await _context.Folders.Include("Sets").Where(f => f.Owner.Equals(username)).ToListAsync();
            if (folders is null)
                return Ok(new List<Folder>());
            return Ok(folders);
        }

        [HttpGet("{folderId}")]
        public async Task<ActionResult<Folder>> GetFolderById(int folderId)
        {
            var folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == folderId);
            if (folder is null)
                return NotFound("This folder does not exist!");
            return Ok(folder);
        }

        [HttpPost]
        public async Task<ActionResult<Folder>> CreateFolder(Folder folder)
        {
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
