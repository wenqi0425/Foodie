using Foodie.Models;
using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<Recipe> SearchRecipesByCriteria(string category, string criteria);
    }
}
