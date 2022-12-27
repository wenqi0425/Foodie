using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Pages.Wrappers
{
    /*
    public class DeleteRecipeModel : PageModel
    {
        private readonly Foodie.Models.AppDbContext _context;

        public DeleteRecipeModel(Foodie.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wrapper Wrapper { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wrapper = await _context.Wrapper.FirstOrDefaultAsync(m => m.WrapperId == id);

            if (Wrapper == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wrapper = await _context.Wrapper.FindAsync(id);

            if (Wrapper != null)
            {
                _context.Wrapper.Remove(Wrapper);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }*/
}
