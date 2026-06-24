using PersonalBlog.Controllers;

namespace PersonalBlog.Services.IServices
{
    public interface ICommentServices
    {
        //Get the comments of the  post by slug
        Task<List<Object>> GetPostCommentsBySlugAsync(string slug);

        //Create comments
        Task CreateCommentsAsync(CreateCommentDto dto);

        //Delete comments
        Task DeleteCommentsAsync(int id);
    }
}
