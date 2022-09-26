using DatabaseHomework.DbProvider;
using DatabaseHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHomework.Controllers;


[Route("[controller]s")]
[ApiController]
public class FolderController : ControllerBase
{

    private readonly PatikaDbContext _patikaDbContext;

    public FolderController(PatikaDbContext patikaDbContext)
    {
        _patikaDbContext = patikaDbContext;
    }

    [HttpGet("GetFolder")]
    public async Task<IActionResult> GetFolder(int id)
    {
        Folder folder = await _patikaDbContext.Folder.Where(x => x.folderid == id).FirstOrDefaultAsync();
        if (folder == null) return NotFound();

        return Ok(folder);
    }

    [HttpGet("GetFolders")]
    public async Task<IEnumerable<Folder>> GetFolders()
    {
        IEnumerable<Folder> folders = await _patikaDbContext.Folder.ToListAsync();
        return folders;
    }

    [HttpPut("ChangeAccessType")]
    public async Task<IActionResult> ChangeFolderName(int id, string newAccess)
    {
        Folder folder = await _patikaDbContext.Folder.Where(x => x.folderid == id).FirstOrDefaultAsync();
        if (folder == null) return NotFound();
        folder.accesstype = newAccess;
        await _patikaDbContext.SaveChangesAsync();
        return Ok(folder);
    }

    [HttpPost("AddNewFolder")]
    public async Task<IActionResult> AddNewFolder([FromQuery] Folder folder)
    {
        await _patikaDbContext.AddAsync(folder);
        await _patikaDbContext.SaveChangesAsync();
        return Ok(folder);
    }

    [HttpDelete("DeleteFolder")]
    public async Task<IActionResult> DeleteFolder(int id)
    {
        Folder folder = await _patikaDbContext.Folder.Where(x => x.folderid == id).FirstOrDefaultAsync();
        if (folder == null) return NotFound();
        _patikaDbContext.Remove(folder);
        await _patikaDbContext.SaveChangesAsync();
        return Ok(folder);
    }
}