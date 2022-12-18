using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Pages.Recipes
{
    public class GetAllRecipesModel : PageModel
    {
        private readonly AppDbContext _context;

        public GetAllRecipesModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await _context.Recipes.ToListAsync();
        }
    }
}
