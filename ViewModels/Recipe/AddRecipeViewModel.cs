using System.ComponentModel.DataAnnotations;
using recipes.Helpers;

namespace recipes.ViewModels.Recipe
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Professional
    }

    public class AddRecipeViewModel
    {
        [Required(ErrorMessage = "Title field is required.")]
        public string Title { get; set; }

        [GreaterThan(0)]
        public int CookingTime { get; set; }

        [Required(ErrorMessage = "Difficulty field is required")]
        public Difficulty Difficulty { get; set; }

        [ListValidation("step")]
        public List<string>? Steps { get; set; } = null;

        [ListValidation("ingredient")]
        public List<string>? Ingredients { get; set; } = null;

        public string DateCreated { get; set; } = DateTime.Now.ToString();

        public string? Username { get; set; }
    }
}