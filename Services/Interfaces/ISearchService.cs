using Foodie.Models;
using Foodie.Pages;

using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface ISearchService
    {
        //IEnumerable<Recipe> SearchRecipesByCriteria(string category, string criteria);
        IEnumerable<Recipe> SearchRecipesByCriteria(RecipeCriteriaModel RecipeCriteria);
    }
}
