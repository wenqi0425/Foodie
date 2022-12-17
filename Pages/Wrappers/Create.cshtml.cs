using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodie.Models;
using System.IO;

namespace Foodie.Pages.Wrappers
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty] public Wrapper WrapperData { get; set; }
        [BindProperty] public Recipe Recipe { get; set; }
        [BindProperty] public RecipeItem RecipeItem { get; set; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [HttpPost]
        public IActionResult OnPostAsync(Wrapper wrapper)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            wrapper.Recipe = new Recipe();
            wrapper.RecipeItem = new RecipeItem();

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

            wrapper.RecipeItem.RecipeId = wrapper.Recipe.Id;

            _context.Recipes.Add(Recipe);
            _context.RecipeItems.Add(RecipeItem);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
