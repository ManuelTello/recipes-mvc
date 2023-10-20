using Azure.Identity;
using recipes.Models;
using recipes.ViewModels.Recipe;

namespace recipes.Lib
{
    public class RecipeMapper
    {
        public RecipeMapper()
        {

        }

        public Recipe MapModelToEntity(AddRecipeViewModel model, User user)
        {
            Common<string> common = new Common<string>();

            Recipe recipe = new Recipe()
            {
                Title = model.Title,
                CookingTime = model.CookingTime,
                Steps = common.ParseListToString(model.Steps!),
                Ingredients = common.ParseListToString(model.Ingredients!),
                DateCreated = model.DateCreated,
                User = user,
                Difficulty = model.Difficulty.ToString()
            };

            return recipe;
        }

        public RecipeViewModel MapEntityToModel(Recipe recipe)
        {
            Common<string> common = new Common<string>();

            RecipeViewModel model = new RecipeViewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                CookingTime = recipe.CookingTime,
                DateCreated = recipe.DateCreated,
                Username = recipe.User.Username,
                Difficulty = recipe.Difficulty,
                Steps = common.ParseStringToList(recipe.Steps),
                Ingredients = common.ParseStringToList(recipe.Ingredients)
            };

            return model;
        }

        public List<RecipeViewModel> MapUnitToList(List<Recipe> recipes)
        {
            List<RecipeViewModel> model = new List<RecipeViewModel>();

            foreach (Recipe r in recipes)
            {
                model.Add(this.MapEntityToModel(r));
            }

            return model;
        }
    }
}