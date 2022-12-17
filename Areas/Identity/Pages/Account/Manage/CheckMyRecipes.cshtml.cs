using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    public class CheckMyRecipesModel : PageModel
    {
        private UserManager<AppUser> _manager;

        private IRecipeService _recipeService;
        public IEnumerable<Recipe> MyRecipes;
        public Recipe Recipe { get; set; }

        // private IRecipeItemService _recipeItemService;
        //public IEnumerable<RecipeItem> ItemsOfOneRecipe;

        public CheckMyRecipesModel(UserManager<AppUser> manager, IRecipeService recipeService/*, IRecipeItemService itemService*/)
        {
            _recipeService = recipeService;
            //_recipeItemService = itemService;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            MyRecipes = _recipeService.GetRecipesByUser(user);
            //ItemsOfOneRecipe = _recipeItemService.GetRecipeItemsByRecipe(Recipe);
           
        }
    }
}
