using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Posts
{
    public class DetailModel : PageModel
    {
        private readonly PostService _postService;

        public DetailModel(PostService postService)
        {
            this._postService = postService;
        }
        public Post Post { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string slug)
        {
            var post = await _postService.GetPostBySlugAsync(slug);
            if (post == null)
            {
                return NotFound("The post is not found!");
            }
            Post = post;
            return Page();
        }
    }
}
