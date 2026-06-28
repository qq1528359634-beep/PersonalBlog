using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PostService _postService;

        public IndexModel(PostService postService)
        {
            this._postService = postService;
        }
        public List<Post> Posts { get; set; } = new();

        public async Task OnGetAsync()
        {
            Posts = await _postService.GetAllPostsAsync();
        }
    }
}
