using Foodie.Models;
using Foodie.Services.EFServices;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //public IActionResult OnGetAsync(int recipeId)
        //{
        //    Recipe = _recipeService.GetRecipeById(recipeId);
        //    return Page();
        //}

        public async Task OnGetAsync(int recipeId) // must be the same as the asp-route-recipeId
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            RecipeItems = _recipeItemService.GetRecipeItemsByRecipeId(recipeId).ToList();
            //return Page();
        }

        public IActionResult OnPost(Recipe recipe)
        {
            _recipeService.DeleteRecipe(recipe);
            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
