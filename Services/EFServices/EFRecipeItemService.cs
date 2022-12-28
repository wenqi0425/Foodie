using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

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

        //public IEnumerable<Recipe> FilterRecipe(string recipeName)
        //{
        //    IEnumerable<Recipe> recipes = _context.Recipes
        //        .Where(r => r.RecipeItems == recipeName).ToList();

        //    return recipes;
        //}
    }
}
