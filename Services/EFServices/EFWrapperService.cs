using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace Foodie.Services.EFServices
{
    public class EFWrapperService : IWrapperService
    {
        AppDbContext _context;

        [BindProperty] public Wrapper WrapperData { get; set; }

        public EFWrapperService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void AddRecipeItems(RecipeItem recipeItem)
        {
            _context.RecipeItems.Add(recipeItem);
            _context.SaveChanges();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Remove(recipeItem);
            _context.SaveChanges();
        }

        public void EditRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void EditRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Update(recipeItem);
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

        public IEnumerable<Recipe> GetRecipesByRecipeName(string recipeName)
        {
            IEnumerable<Recipe> recipes = _context.Recipes
                .Where(r => r.Name == recipeName).ToList();

            return recipes;
        }

        public IEnumerable<Recipe> GetRecipesByUser(AppUser user)
        {
            IEnumerable<Recipe> recipes = _context.Recipes
                .Where(r => r.User == user).ToList();

            return recipes;
        }
    }
}
