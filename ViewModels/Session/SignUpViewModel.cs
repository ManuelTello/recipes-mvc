using System.ComponentModel.DataAnnotations;

namespace recipes.ViewModels.Session
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email field is required.")]
        [RegularExpression(@"^\S*@\S*\.\S*", ErrorMessage = "Must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters.")]
        public string Password { get; set; }
    }
}