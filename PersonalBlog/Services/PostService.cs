using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Services.IServices;

namespace PersonalBlog.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _Context;

        public PostService(BlogDbContext Context)
        {
            this._Context = Context;
        }

        //Get all Publishde Posts
        public async Task<List<Post>> GetPublishedPostsAsync()
        {
            return await _Context.Posts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        //Get  a Published  Post by slug
        public async Task<Post?> GetPostBySlugAsync(string slug)
        {
            return await _Context.Posts
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsPublished);
        }

        //Create Post
        public async Task CreatPostAsync(Post post)
        {
            _Context.Posts.Add(post);
            await _Context.SaveChangesAsync();
        }
        //Update Post
        public async Task UpdatePostAsync(Post post)
        {
            post.UpdatedAt = DateTime.UtcNow;
            _Context.Update(post);
            await _Context.SaveChangesAsync();
        }
        //delete Post
        public async Task DeletePostAsync(int id)
        {
            var post = await _Context.Posts.FindAsync(id);
            if (post != null)
            {
                _Context.Posts.Remove(post);
                await _Context.SaveChangesAsync();
            }
        }
        //Get all Posts
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _Context.Posts
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

    }
}
