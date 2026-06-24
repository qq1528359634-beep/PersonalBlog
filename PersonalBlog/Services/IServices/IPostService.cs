using PersonalBlog.Models;

namespace PersonalBlog.Services.IServices
{
    public interface IPostService
    {
        Task CreatPostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<List<Post>> GetAllPostsAsync();
        Task<Post?> GetPostBySlugAsync(string slug);
        Task<List<Post>> GetPublishedPostsAsync();
        Task UpdatePostAsync(Post post);
    }
}