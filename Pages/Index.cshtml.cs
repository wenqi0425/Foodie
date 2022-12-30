using Foodie.Models;
using Foodie.Pages.Recipes;
using Foodie.Services.EFServices;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public SelectList SearchCategories { get; set; }

        [BindProperty]
        public RecipeCriteriaModel RecipeCriteria { get; set; } = new RecipeCriteriaModel();

        public IActionResult OnPost()
        {
            return RedirectToPage("/Recipes/GetRecipes", RecipeCriteria);
        }
    }
}
