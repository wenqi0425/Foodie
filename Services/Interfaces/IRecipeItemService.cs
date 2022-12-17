﻿using Foodie.Models;
using System.Collections.Generic;

namespace Foodie.Services.Interfaces
{
    public interface IRecipeItemService
    {
        void AddRecipeItem(RecipeItem recipe);
        void DeleteRecipeItem(RecipeItem recipe);
        void EditRecipeItem(RecipeItem recipe);
        IEnumerable<RecipeItem> GetRecipeItemsByRecipe(Recipe recipe);
    }
}