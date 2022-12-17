using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Pages.RecipeItems
{
    public class EditModel : PageModel
    {
        private readonly Foodie.Models.AppDbContext _context;

        public EditModel(Foodie.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeItem = await _context.RecipeItems
                .Include(r => r.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeItem == null)
            {
                return NotFound();
            }
           ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "CookingSteps");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecipeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeItemExists(RecipeItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeItemExists(int id)
        {
            return _context.RecipeItems.Any(e => e.Id == id);
        }
    }
}
