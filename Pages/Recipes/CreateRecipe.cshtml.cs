using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodie.Models;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Foodie.Services.EFServices;

namespace Foodie.Pages.Recipes
{
    public class CreateRecipeModel : PageModel
    {
        private readonly AppDbContext _context;
        public string Message { get; set; }        
        
        IRecipeService recipeService;        
        UserManager<AppUser> userManager;
        
        [BindProperty] public Recipe Recipe { get; set; }
        public CreateRecipeModel(IRecipeService service, UserManager<AppUser> manager)
        {
            this.recipeService = service;
            this.userManager = manager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await userManager.GetUserAsync(User);
            var myRecipes = recipeService.GetRecipesByUser(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            Message = "The recipe has been saved.";

            return RedirectToPage("./Index");
        }
    }
}
