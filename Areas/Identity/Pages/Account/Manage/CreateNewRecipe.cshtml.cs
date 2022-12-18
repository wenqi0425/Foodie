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
    public class CreateNewRecipeModel : PageModel
    {
        public Recipe Recipe { get; set; }
        public AppUser AppUser { get; set; }
        public string Message { get; set; }

        private UserManager<AppUser> _manager;
        private IRecipeService _recipeService;
        public List<Recipe> MyRecipes;

        AppDbContext _context;

        public CreateNewRecipeModel(UserManager<AppUser> manager, IRecipeService recipeService,
            AppDbContext context)
        {
            _recipeService = recipeService;
            _manager = manager;
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

            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
