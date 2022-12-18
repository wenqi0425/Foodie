using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

using System.IO;

using System;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    public class CreateRecipeItemModel : PageModel
    {
        [BindProperty] public Recipe Recipe { get; set; }
        [BindProperty] public RecipeItem RecipeItem { get; set; }

        public AppUser appUser { get; set; }
        public string Message { get; set; }

        public UserManager<AppUser> _manager;
        public IRecipeService _recipeService;
        public IRecipeItemService _recipeItemService;
        public IEnumerable<RecipeItem> _recipesItemsOfOneRecipe;

        AppDbContext _context;

        public CreateRecipeItemModel(UserManager<AppUser> manager, IRecipeService recipeService,
            IRecipeItemService recipeItemService, AppDbContext context)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
            _manager = manager;
            _recipeItemService = recipeItemService;
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [HttpPost]
        public ActionResult OnPost()
        {
            var currentUserId = _manager.GetUserId(User);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Recipe.UserId = Int32.Parse(currentUserId);
            var pesistedReceipe = _context.Recipes.Add(Recipe);
            _context.SaveChanges();

            RecipeItem.RecipeId = pesistedReceipe.Entity.Id;
            _context.RecipeItems.Add(RecipeItem);
            _context.SaveChanges();

            return RedirectToPage("./CreateMyRecipes");
        }
    }
}
