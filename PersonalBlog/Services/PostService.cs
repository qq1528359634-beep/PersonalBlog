using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Services
{
    public class PostService
    {
        private readonly BlogDbContext _Context;

        public PostService(BlogDbContext Context)
        {
            this._Context = Context;
        }


        public async Task<List<Post>> GetPublishedPosts()
        {
            return await _Context.Posts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        //找寻某篇文章 
        //あるpostを特定する
        public async Task<Post?> GetPostBySlug(string slug)
        {
            return await _Context.Posts
                .FirstOrDefaultAsync(p => p.Slug == slug && p.IsPublished);
        }

        //新增文章
        public async Task CreatPostAsync(Post post)
        {
            _Context.Posts.Add(post);
            await _Context.SaveChangesAsync();
        }
        //更新文章
        public async Task UpdatePostAsync(Post post)
        {
            post.UpdatedAt = DateTime.UtcNow;
            _Context.Update(post);
            await _Context.SaveChangesAsync();
        }
        //删除文章
        public async Task DeletePostAsync(int id)
        {
            var post =await _Context.Posts.FindAsync(id);
            if (post != null)
            {
                _Context.Posts.Remove(post);
             await _Context.SaveChangesAsync();
            }
        }

    }
}
