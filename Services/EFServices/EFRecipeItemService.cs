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

        public IEnumerable<RecipeItem> GetRecipeItemsByRecipe(Recipe recipe)
        {
            IEnumerable<RecipeItem> recipeItems = _context.RecipeItems
                .Where(i => i.Recipe == recipe).ToList();

            return recipeItems;
        }
    }
}
