using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class CheckMyRecipesModel : PageModel
    {
        private UserManager<AppUser> _manager;

        private IRecipeService _recipeService;
        public IEnumerable<Recipe> MyRecipes;
        public Recipe Recipe { get; set; }

        public CheckMyRecipesModel(UserManager<AppUser> manager, IRecipeService recipeService)
        {
            _recipeService = recipeService;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            MyRecipes = _recipeService.GetRecipesByUser(user);           
        }
    }
}
