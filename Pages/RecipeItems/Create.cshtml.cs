using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodie.Models;

namespace Foodie.Pages.RecipeItems
{
    public class CreateModel : PageModel
    {
        private readonly Foodie.Models.AppDbContext _context;

        public CreateModel(Foodie.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps");
            return Page();
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeItems.Add(RecipeItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
