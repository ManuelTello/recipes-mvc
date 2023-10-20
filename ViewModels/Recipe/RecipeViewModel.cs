namespace recipes.ViewModels.Recipe
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> Steps { get; set; }

        public List<string> Ingredients { get; set; }

        public string DateCreated { get; set; }

        public string Difficulty { get; set; }

        public int CookingTime { get; set; }

        public string Username { get; set; }
    }
}