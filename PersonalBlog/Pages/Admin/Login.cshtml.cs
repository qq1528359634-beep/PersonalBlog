using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace PersonalBlog.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _config;

        public LoginModel(IConfiguration config)
        {
            this._config = config;
        }
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var correctPassWord = _config["AdminPassword"];
            if (Password!=correctPassWord)
            {
                ErrorMessage = "unCorrect password!";
                return Page();
            }

            //Create login credentials
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Admin"),
                new Claim(ClaimTypes.Role,"Admin"),

            };
            //Create login credentials
            var identity = new ClaimsIdentity(claims,"BlogCookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("BlogCookies",principal);
            return RedirectToPage("/Admin/Index");

        }
    }
}
