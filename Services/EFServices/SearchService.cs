using Foodie.Models;
using Foodie.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            var criterion = RecipeCriteria.SearchCriterion;

            if (!string.IsNullOrEmpty(category) && category.Equals("Recipe"))
            {
                Recipes = _recipeService.SearchRecipes(criterion);
            }

            else if (!string.IsNullOrEmpty(category) && category.Equals("Ingredient"))
            {
                Recipes = _recipeItemService.SearchRecipes(criterion);
            }

            else
            {
                Recipes = _recipeService.GetAllRecipes();
            }

            Recipes = Enumerable.Reverse(Recipes);

            return Recipes;
        }
    }
}
