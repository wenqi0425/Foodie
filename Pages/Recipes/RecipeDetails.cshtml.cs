using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Foodie.Models;
using Foodie.Services.Interfaces;

namespace Foodie.Pages.Recipes
{
    [BindProperties]
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public RecipeDetailsModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
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
    }
}
