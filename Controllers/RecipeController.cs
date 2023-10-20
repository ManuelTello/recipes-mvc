using Microsoft.AspNetCore.Mvc;
using recipes.Data;
using recipes.Models;
using recipes.Services;
using recipes.ViewModels.Recipe;

namespace recipes.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService Service;

        private readonly string SessionKey;

        public RecipeController(DataContext context, IConfiguration configuration)
        {
            this.Service = new RecipeService(context);
            this.SessionKey = configuration.GetConnectionString("sessionkey");
        }

        [HttpGet]
        [Route("{controller}/addrecipe")]
        public IActionResult AddRecipe()
        {
            AddRecipeViewModel model = new AddRecipeViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("{controller}/addrecipe")]
        public async Task<IActionResult> AddRecipeValidation(AddRecipeViewModel model)
        {
            model.Username = HttpContext.Session.GetString(this.SessionKey);

            if (ModelState.IsValid)
            {
                await this.Service.AddRecipe(model);
                return RedirectToAction("UserPanel", "Session");
            }
            else
            {
                return View("AddRecipe", model);
            }
        }

        [HttpGet]
        [Route("{controller}/{action}/{recipeid:int}")]
        public async Task<IActionResult> Search(int recipeid)
        {
            RecipeViewModel? model = await this.Service.FindRecipeById(recipeid);
            return View("Recipe", model);
        }

        [HttpGet]
        [Route("{controllerl}/{action}")]
        public async Task<IActionResult> Search(MultipleReciepsViewModel model)
        {
            if (model.Title != null || model.Title == "")
            {
                model.Recipes = await this.Service.FilterRecipes(model);
            }

            return View("MultipleRecipes", model);
        }
    }
}