using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace Foodie.Services.EFServices
{
    public class EFRecipeService : IRecipeService
    {
        AppDbContext _context;

        public EFRecipeService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }

        public void EditRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return _context.Recipes.FirstOrDefault(r => r.Id == recipeId);
        }

        public IEnumerable<Recipe> GetRecipesByName(string recipeName)
        {
            IEnumerable<Recipe> recipes = _context.Recipes
                .Where(r => r.Name == recipeName).ToList();

            return recipes;
        }
    }
}
