using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Pages.RecipeItems
{
    public class DetailsModel : PageModel
    {
        private readonly Foodie.Models.AppDbContext _context;

        public DetailsModel(Foodie.Models.AppDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
