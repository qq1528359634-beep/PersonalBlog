using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Services;
using PersonalBlog.Models;

namespace PersonalBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;

        public IndexModel(IPostService postService)
        {
            this._postService = postService;
        }
        public List<Post> Posts { get; set; } = new List<Post>();

        public async Task GetOnAsync()
        {
            Posts = await _postService.GetPublishedPostsAsync();
        }
    }
}
