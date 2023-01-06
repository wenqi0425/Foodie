using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Foodie.Models;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Foodie.Pages.Recipes
{
    public class GetRecipesModel : PageModel
    {
        // Code can be reused through SearchService
        private ISearchService _searchService;

        public GetRecipesModel(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IList<Recipe> Recipes { get; set; }
        public string ScreenMessage { get; set; }
        public SelectList SearchCategories { get; set; }

        [BindProperty(SupportsGet = true)] public RecipeCriteriaModel RecipeCriteria { get; set; } = new RecipeCriteriaModel();

        public void OnGet()
        {
            Recipes = _searchService.SearchRecipesByCriteria(RecipeCriteria).ToList();
            if (Recipes.Count() == 0)
            {
                ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
            }
        }

        #region Code before reuse
        /*
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public GetRecipesModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Search.SearchCategory) && Search.SearchCategory.Equals("Recipe"))
            {
                Recipes = _recipeService.SearchRecipes(Search.SearchCriterion).ToList();
                if (Recipes.Count() == 0)
                {
                    ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
                }
            }

            else if (!string.IsNullOrEmpty(Search.SearchCategory) && Search.SearchCategory.Equals("Ingredient"))
            {
                Recipes = _recipeItemService.SearchRecipes(Search.SearchCriterion).ToList();
                if (Recipes.Count() == 0)
                {
                    ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
                }
            }

            else
            {
                Recipes = _recipeService.GetAllRecipes().ToList();
            }
        }*/
        #endregion
    }
}
