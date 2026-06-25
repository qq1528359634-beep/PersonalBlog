using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Controllers;
using PersonalBlog.Services.IServices;

namespace PersonalBlog.Services
{
    public class CommentService:ICommentService
    {
        private readonly BlogDbContext _context;

        public CommentService(BlogDbContext context)
        {
            this._context = context;
        }
        //Get the comments of the  post by slug
        public async Task<List<Object>> GetPostCommentsBySlugAsync(string slug)
        {
            return await _context.Comments
                .Where(c => c.post.Slug == slug)
                .OrderByDescending(c => c.CreateAt)
                .Select(c => new
                {
                    c.Id,
                    c.Content,
                    c.AuthorName,
                    CreateAt = c.CreateAt.ToString("yyyy-MM-dd HH:mm")
                }).ToListAsync<Object>();
        }
        //Create comments
        public async Task CreateCommentsAsync(CreateCommentDto dto)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.Slug == dto.Slug);
            if (post == null) return;
            Comment comment = new()
            {
                PostId = post.Id,
                Content = dto.Content,
                AuthorName = dto.AuthorName
            };
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
        //Delete comments
        public async Task DeleteCommentsAsync(int id)
        {
            var comment = await _context.Comments
                 .FindAsync(id);
            if (comment!=null)
            {
                _context.Comments.Remove(comment);
               await _context.SaveChangesAsync();
            }

        }
    }

}
