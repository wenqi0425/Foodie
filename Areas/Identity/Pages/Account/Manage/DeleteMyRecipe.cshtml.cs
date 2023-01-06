using Foodie.Models;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    [BindProperties]
    public class DeleteMyRecipeModel : PageModel
    {
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public DeleteMyRecipeModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
        }

        public RecipeItem RecipeItem { get; set; }
        public Recipe Recipe { get; set; }
        public IList<RecipeItem> RecipeItems { get; set; }

        public RecipeItem RecipeItem1 { get; set; }
        public RecipeItem RecipeItem2 { get; set; }
        public RecipeItem RecipeItem3 { get; set; }
        public RecipeItem RecipeItem4 { get; set; }
        public RecipeItem RecipeItem5 { get; set; }

        public void OnGet(int recipeId) // asp-route-recipeId
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            RecipeItems = _recipeItemService.GetRecipeItemsByRecipeId(recipeId).ToList();
        }

        public IActionResult OnPost(Recipe recipe)
        {
            _recipeService.DeleteRecipe(recipe);
            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
