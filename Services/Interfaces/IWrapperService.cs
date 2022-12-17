using Foodie.Models;
using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface IWrapperService
    {
        void AddRecipe(Recipe recipe);
        void EditRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);        
        Recipe GetRecipeById(int recipeId);
        IEnumerable<Recipe> GetAllRecipes();
        IEnumerable<Recipe> GetRecipesByRecipeName(string recipeName);
        IEnumerable<Recipe> GetRecipesByUser(AppUser user);

        void AddRecipeItems(RecipeItem recipeItem);
        void EditRecipeItem(RecipeItem recipeItem);
        void DeleteRecipeItem(RecipeItem recipeItem);
    }
}
