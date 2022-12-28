using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Foodie.Services.EFServices
{
    public class EFRecipeItemService : IRecipeItemService
    {
        AppDbContext _context;
        public EFRecipeItemService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Add(recipeItem);
            _context.SaveChanges();
        }

        public void DeleteRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Remove(recipeItem);
            _context.SaveChanges();
        }

        public void EditRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Update(recipeItem);
            _context.SaveChanges();
        }

        public IEnumerable<RecipeItem> GetRecipeItemsByRecipeId(int recipeId)
        {
            IEnumerable<RecipeItem> recipeItems = _context.RecipeItems
                .Where(item => item.RecipeId == recipeId).ToList();

            return recipeItems;
        }

        //public IEnumerable<Recipe> SearchRecipes(string ingredient)
        //{
        //    IEnumerable<Recipe> recipes = _context.Recipes
        //        .Where(recipe => recipe.RecipeItems.Select(item=>item.Name).ToList().Contains(ingredient));

        //    return recipes;
        //}

        public IEnumerable<Recipe> SearchRecipes(string ingredient)
        {
            IEnumerable<Recipe> recipes = _context.RecipeItems
                .Where(item => item.Name.Equals(ingredient))
                .Select(item=>item.Recipe)
                .ToList();

            return recipes;
        }
    }
}
