using Foodie.Models;
using Foodie.Pages;
using Foodie.Services.Interfaces;

using System.Collections.Generic;

namespace Foodie.Services.EFServices
{
    public class SearchService : ISearchService
    {
        private readonly IRecipeItemService _recipeItemService;
        private readonly IRecipeService _recipeService;

        public SearchService(IRecipeItemService recipeItemService, IRecipeService recipeService)
        {
            _recipeItemService = recipeItemService;
            _recipeService = recipeService;
        }

        public IEnumerable<Recipe> SearchRecipesByCriteria(RecipeCriteriaModel RecipeCriteria)            
        {
            IEnumerable<Recipe> Recipes;

            var category = RecipeCriteria.SearchCategory;
            var criteria = RecipeCriteria.SearchString;

            if (!string.IsNullOrEmpty(category) && category.Equals("Recipe"))
            {
                Recipes = _recipeService.SearchRecipes(criteria);
            }

            else if (!string.IsNullOrEmpty(category) && category.Equals("Ingredient"))
            {
                Recipes = _recipeItemService.SearchRecipes(criteria);
            }

            else
            {
                Recipes = _recipeService.GetAllRecipes();
            }

            return Recipes;
        }
    }
}
