using Foodie.Models;
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

        public IEnumerable<Recipe> SearchRecipesByCriteria(string category, string criteria)
        {
            IEnumerable<Recipe> Recipes;

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
