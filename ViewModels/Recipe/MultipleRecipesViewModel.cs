using System.ComponentModel.DataAnnotations;

namespace recipes.ViewModels.Recipe
{
    public enum Order
    {
        Ascendant,
        Descendant
    }

    public class MultipleReciepsViewModel
    {

        public string Title { get; set; }

        public int Page { get; set; } = 0;

        public int Take { get; set; } = 0;

        public int MaxPages { get; set; } = 0;

        [Display(Name = "Minimum cooking time")]
        public int? CookingTimeMin { get; set; }

        [Display(Name = "Maximum cooking time")]
        public int? CookingTimeMax { get; set; }

        [Display(Name = "Create in")]
        public DateTime? TimeStampMin { get; set; }

        [Display(Name = "Created to")]
        public DateTime? TimeStampMax { get; set; }

        public List<RecipeViewModel> Recipes { get; set; }

        public Difficulty? Difficulty { get; set; } = null;

        public Order? Order { get; set; }
    }
}