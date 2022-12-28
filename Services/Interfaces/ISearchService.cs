using Foodie.Models;
using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<Recipe> SearchRecipeByRecipeName(string recipeName);
        IEnumerable<Recipe> SearchRecipeByIngredient(string ingredient);
    }
}
