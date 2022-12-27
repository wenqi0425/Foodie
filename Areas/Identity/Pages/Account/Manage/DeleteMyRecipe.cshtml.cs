using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class DeleteMyRecipeModel : PageModel
    {
        IRecipeService _recipeService;

        public DeleteMyRecipeModel(IRecipeService service)
        {
            _recipeService = service;
        }

        [BindProperty] public Recipe Recipe { get; set; }
        [BindProperty] public IList<RecipeItem> RecipeItems { get; set; }

        public IActionResult OnGetAsync(int recipeId)
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            return Page();
        }

        public IActionResult OnPost(Recipe recipe)
        {
            _recipeService.DeleteRecipe(recipe);
            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
