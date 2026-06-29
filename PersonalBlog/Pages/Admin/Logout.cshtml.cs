using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Pages.Admin
{
    public class LogoutModel:PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {   //sign out Cookie
            await HttpContext.SignOutAsync("BlogCookies");
            return RedirectToPage("/Posts/Index");
        }
    }
}
