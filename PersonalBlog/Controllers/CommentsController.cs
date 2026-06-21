using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Services;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers;

public record CreateCommentDto(string Slug, string AuthorName, string Content);

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly CommentServices _commentServices;

    public CommentsController(CommentServices commentServices)
    {
        this._commentServices = commentServices;
    }

    //Get comments by slug
    //api/comments?slug=first-post
    [HttpGet]
    public async Task<IActionResult> GetComments([FromForm] string slug)
    {
        var comments = await _commentServices.GetPostCommentsBySlugAsync(slug);
        return Ok(comments);
    }
    //Post /api/comments
    [HttpPost]
    public async Task<IActionResult> CreatComment([FromBody] CreateCommentDto dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Content) || !string.IsNullOrWhiteSpace(dto.AuthorName))
        {
            return BadRequest("Author name and Content can not be empty!");
        }
        await _commentServices.CreateCommentsAsync(dto);
        return Ok();
    }
    //api/comments/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _commentServices.DeleteCommentsAsync(id);
        return NoContent();
    }

}
