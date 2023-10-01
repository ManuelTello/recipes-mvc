using System.ComponentModel.DataAnnotations;

namespace recipes.ViewModels.Session
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Username field is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; } = string.Empty;
    }
}