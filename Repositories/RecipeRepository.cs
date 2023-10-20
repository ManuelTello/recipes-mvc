using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using recipes.Data;
using recipes.Models;

namespace recipes.Repositories
{
    public class RecipeRepository
    {
        private readonly DataContext Context;

        public RecipeRepository(DataContext context)
        {
            this.Context = context;
        }

        public async Task AddNewRecipe(Recipe recipe)
        {
            await this.Context.Recipes.AddAsync(recipe);
            await this.Context.SaveChangesAsync();
        }

        public async Task<User> FindUserByName(string username)
        {
            User user = await this.Context.Users.SingleAsync(u => u.Username == username);
            return user;
        }

        public async Task<Recipe?> FindRecipe(int id)
        {
            Recipe? recipe = await this.Context.Recipes
                .Include(r => r.User)
                .SingleOrDefaultAsync(r => r.Id == id);
            return recipe;
        }

        public async Task<List<Recipe>> FindTitleByRegex(string title)
        {
            List<Recipe> recipes = await this.Context.Recipes
                .Where(r => EF.Functions.Like(r.Title, $"%{title}%"))
                .Include(r => r.User)
                .ToListAsync();

            return recipes;
        }
    }
}