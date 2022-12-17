using Foodie.Models;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    public class CreateMyRecipesModel : PageModel
    {
        [BindProperty] public Recipe Recipe { get; set; }
        [BindProperty] public RecipeItem RecipeItem { get; set; }
        
        public AppUser appUser { get; set; }
        public string Message { get; set; }

        public UserManager<AppUser> _manager;
        public IRecipeService _recipeService;
        public IEnumerable<Recipe> _myRecipesList;

        public IRecipeItemService _recipeItemService;
        public IEnumerable<RecipeItem> _recipesOfOneRecipe;

        AppDbContext _context;

        public CreateMyRecipesModel(UserManager<AppUser> manager, IRecipeService recipeService, 
            IRecipeItemService recipeItemService, IEnumerable<Recipe> myRecipesList, 
            IEnumerable<RecipeItem> recipesOfOneRecipe, AppDbContext context)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
            _manager = manager;
            _myRecipesList = myRecipesList;
            _recipeItemService = recipeItemService;
            _recipesOfOneRecipe = recipesOfOneRecipe;
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

            byte[] bytes = null;

            if (Recipe.ImageFile != null)
            {
                using (Stream s = Recipe.ImageFile.OpenReadStream())
                {
                    using (BinaryReader r = new BinaryReader(s))
                    {
                        bytes = r.ReadBytes((Int32)s.Length);
                    }
                }

                Recipe.ImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            Recipe.UserId = Int32.Parse(currentUserId);
            var pesistedReceipe = _context.Recipes.Add(Recipe);
            _context.SaveChanges();

            RecipeItem.RecipeId = pesistedReceipe.Entity.Id;
            _context.RecipeItems.Add(RecipeItem);
            _context.SaveChanges();

            return RedirectToPage("./CheckMyRecipesModel");
        }
    }
}
