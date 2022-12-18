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
    [BindProperties]
    public class CreateMyRecipesModel : PageModel
    {
        public Recipe Recipe { get; set; }
        public RecipeItem RecipeItem { get; set; }
        
        public AppUser AppUser { get; set; }
        public string Message { get; set; }

        private UserManager<AppUser> _manager;
        private IRecipeService _recipeService;

        public IRecipeItemService _recipeItemService;
        public List<RecipeItem> RecipeItemsOfOneRecipe;

        AppDbContext _context;

        public CreateMyRecipesModel(UserManager<AppUser> manager, IRecipeService recipeService, 
            IRecipeItemService recipeItemService, AppDbContext context)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
            _manager = manager;
            _context = context;
        }
        public IActionResult OnGet(int recipeId)
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
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

            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
