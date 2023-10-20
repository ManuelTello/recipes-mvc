using recipes.Data;
using recipes.Models;
using recipes.Repositories;
using recipes.ViewModels.Recipe;
using recipes.Lib;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace recipes.Services
{
    public class RecipeService
    {
        private readonly RecipeRepository Repository;

        private readonly RecipeMapper Mapper;

        public RecipeService(DataContext context)
        {
            this.Repository = new RecipeRepository(context);
            this.Mapper = new RecipeMapper();
        }

        public async Task AddRecipe(AddRecipeViewModel model)
        {
            User user = await this.Repository.FindUserByName(model.Username);
            Recipe recipe = this.Mapper.MapModelToEntity(model, user);
            await this.Repository.AddNewRecipe(recipe);
        }

        public async Task<RecipeViewModel?> FindRecipeById(int id)
        {
            RecipeViewModel? model;
            Recipe? recipe = await this.Repository.FindRecipe(id);

            if (recipe != null)
            {
                model = Mapper.MapEntityToModel(recipe);
            }
            else
            {
                model = null;
            }

            return model;
        }

        public async Task<List<RecipeViewModel>> FilterRecipes(MultipleReciepsViewModel model)
        {
            List<Recipe> recipes = await this.Repository.FindTitleByRegex(model.Title);

            if (model.CookingTimeMin != null && model.CookingTimeMax != null)
            {
                recipes = recipes.Where(r => r.CookingTime >= model.CookingTimeMin && r.CookingTime <= model.CookingTimeMax).ToList();
            }
            else
            {
                if (model.CookingTimeMin != null)
                {
                    recipes = recipes.Where(r => r.CookingTime >= model.CookingTimeMin).ToList();
                }
                else if (model.CookingTimeMax != null)
                {
                    recipes = recipes.Where(r => r.CookingTime <= model.CookingTimeMax).ToList();
                }
            }

            if (model.TimeStampMin != null && model.TimeStampMax != null)
            {
                recipes = recipes.Where(r => DateTime.Parse(r.DateCreated) >= model.TimeStampMin && DateTime.Parse(r.DateCreated) <= model.TimeStampMax).ToList();
            }
            else
            {
                if (model.TimeStampMin != null)
                {
                    recipes = recipes.Where(r => DateTime.Parse(r.DateCreated) >= model.TimeStampMin).ToList();
                }
                else if (model.TimeStampMax != null)
                {
                    recipes = recipes.Where(r => DateTime.Parse(r.DateCreated) <= model.TimeStampMax).ToList();
                }
            }

            if (model.Difficulty != null)
            {
                recipes = recipes.Where(r => r.Difficulty == model.Difficulty.ToString()).ToList();
            }

            List<RecipeViewModel> model_list = Mapper.MapUnitToList(recipes);

            return model_list;
        }
    }
}