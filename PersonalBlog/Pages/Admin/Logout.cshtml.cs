using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace PersonalBlog.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            //sign out cookie
            await HttpContext.SignOutAsync("BlogCookies");
            return RedirectToPage("/Posts/Index");
        }
    }
}
