using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Posts
{
    public class DetailModel : PageModel
    {
        private readonly IPostService _postService;

        public DetailModel(IPostService postService)
        {
            this._postService = postService;
        }
        public Post Post { get; set; } = default!;

        public string RenderedContent { get; set; } = string.Empty;
        public async Task<IActionResult> OnGetAsync(string slug)
        {
            var post = await _postService.GetPostBySlugAsync(slug);
            if (post == null)
            {
                return NotFound("The post is not found!");
            }
            Post = post;
            RenderedContent = _postService.RenderMarkdown(Post.Content);
            return Page();
        }
    }
}
