using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IPostService _postService;

        public EditModel(IPostService postService)
        {
            this._postService = postService;
        }

        [BindProperty]
        public Post Post { get; set; } = new();
        // Load the article when entering the page
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();
            Post = post;
            return Page();
        }
        // Update Posts upon submission
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _postService.UpdatePostAsync(Post);
            return RedirectToPage("/Admin/Index");
        }
        //delete Posts
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _postService.DeletePostAsync(id);
            return RedirectToPage("/Admin/Index");
        }
    }
}
