using Foodie.Models;
using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface IRecipeService
    {
        void AddRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);
        void EditRecipe(Recipe recipe);
        Recipe GetRecipeById(int recipeId);
        IEnumerable<Recipe> GetAllRecipes();
        IEnumerable<Recipe> GetRecipesByName(string recipeName);        
    }
}
