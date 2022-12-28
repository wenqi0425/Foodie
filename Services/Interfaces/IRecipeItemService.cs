using Foodie.Models;
using Foodie.Pages.Recipes;

using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface IRecipeItemService
    {
        void AddRecipeItem(RecipeItem recipe);
        void DeleteRecipeItem(RecipeItem recipe);
        void EditRecipeItem(RecipeItem recipe);
        IEnumerable<RecipeItem> GetRecipeItemsByRecipeId(int recipeId);
        IEnumerable<Recipe> SearchRecipes(string ingredient);
    }
}
