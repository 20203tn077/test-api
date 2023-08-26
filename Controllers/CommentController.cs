using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CommentController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public Task<IActionResult> Index()
    {
        var comments = _dbContext.Comments;
        if (comments == null || !comments.Any()) return Task.FromResult<IActionResult>(NoContent());
        return Task.FromResult<IActionResult>(Ok(comments));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Show([FromRoute] int id)
    {
        var comment = await _dbContext.Comments!.FindAsync(id);
        if (comment == null) return NotFound();
        return Ok(comment);
    }
    
    [HttpPost]
    public async Task<HttpStatusCode> Store([FromBody] Comment comment)
    {
        _dbContext.Add(comment);
        await _dbContext.SaveChangesAsync();
        return HttpStatusCode.Created;
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Comment comment)
    {
        var entity = await _dbContext.Comments!.FindAsync(comment.Id);
        if (entity == null) return NotFound();
        entity.Title = comment.Title;
        entity.Description = comment.Description;
        entity.Author = comment.Author;
        entity.CreatedAt = comment.CreatedAt;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

	[HttpDelete("{id:int}")]
    public async Task<IActionResult> Destroy([FromRoute] int id)
    {
        var entity = await _dbContext.Comments!.FindAsync(id);
        if (entity == null) return NotFound();
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}