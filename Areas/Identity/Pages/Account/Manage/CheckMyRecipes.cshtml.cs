using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    public class CheckMyRecipes : PageModel
    {
        public Recipe Recipe { get; set; }
        public RecipeItem RecipeItem { get; set; }

        public UserManager<AppUser> _manager;
        public IRecipeService _recipeService;
        public IEnumerable<Recipe> _myRecipesList;

        public IRecipeItemService _recipeItemService;
        public IEnumerable<RecipeItem> _recipesOfOneRecipe;

        public CheckMyRecipes(UserManager<AppUser> manager, IRecipeService recipeService, IRecipeItemService itemService)
        {
            _recipeService = recipeService;
            _recipeItemService = itemService;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            _myRecipesList = _recipeService.GetRecipesByUser(user);
        }
    }
}
