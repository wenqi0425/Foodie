using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Pages.Wrappers
{
    public class EditModel : PageModel
    {
        private readonly Foodie.Models.AppDbContext _context;

        public EditModel(Foodie.Models.AppDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wrapper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WrapperExists(Wrapper.WrapperId))
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

        private bool WrapperExists(int id)
        {
            return _context.Wrapper.Any(e => e.WrapperId == id);
        }
    }
}
