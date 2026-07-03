using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;


namespace PersonalBlog.Pages.Admin
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IPostService _postService;

        public CreateModel(IPostService postService)
        {
            this._postService = postService;
        }
        [BindProperty]
        public Post Post { get; set; } = new();//new a post before bind

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();//keep input content
            Post.Slug = GenerateSlug(Post.Title);
            Post.CreatedAt = DateTime.UtcNow;
            await _postService.CreatPostAsync(Post);
            return RedirectToPage("/Admin/Index");
        }

        private static string GenerateSlug(string title)
        {
            return title.ToLower()
                .Replace(" ", "-")
                .Replace("_", "-");
        }
    }
}
