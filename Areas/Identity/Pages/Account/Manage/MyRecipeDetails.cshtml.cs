using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [BindProperties]
    public class MyRecipeDetailsModel : PageModel
    {
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public MyRecipeDetailsModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
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

        public async Task OnGetAsync(int recipeId) // must be the same as the asp-route-recipeId
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            RecipeItems = _recipeItemService.GetRecipeItemsByRecipeId(recipeId).ToList();
        }
    }
}
