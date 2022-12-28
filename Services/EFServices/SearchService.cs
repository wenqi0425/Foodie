using Foodie.Models;
using Foodie.Services.Interfaces;

using System.Collections.Generic;

namespace Foodie.Services.EFServices
{
    public class SearchService : ISearchService
    {
        public IEnumerable<Recipe> SearchRecipeByIngredient(string ingredient)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipe> SearchRecipeByRecipeName(string recipeName)
        {
            throw new System.NotImplementedException();
        }
    }
}
