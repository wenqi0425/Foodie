using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;
using Foodie.Services.Interfaces;

namespace Foodie.Pages.Recipes
{
    [BindProperties]
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;
        private AppDbContext _context;

        public RecipeDetailsModel(IRecipeService recipeService, IRecipeItemService recipeItemService, AppDbContext context)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
            _context = context;
        }

        public RecipeItem RecipeItem { get; set; }
        public Recipe Recipe { get; set; }
        public IList<RecipeItem> RecipeItems { get; set; }
        public IList<Recipe> Recipes { get; set; }

        public async Task OnGetAsync(int recipeId) // must be the same as the asp-route-recipeId
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            RecipeItems = _recipeItemService.GetRecipeItemsByRecipeId(recipeId).ToList();
        }
    }
}
