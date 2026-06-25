using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        }
    }
}
