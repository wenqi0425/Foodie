using Foodie.Models;
using Foodie.Pages.Recipes;

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
        IEnumerable<Recipe> GetRecipesByRecipeName(string recipeName);
        IEnumerable<Recipe> GetRecipesByUser(AppUser user);
        IEnumerable<Recipe> SearchRecipes(string searchString);
        //IEnumerable<Recipe> SearchRecipes(SearchModel search);
    }
}
