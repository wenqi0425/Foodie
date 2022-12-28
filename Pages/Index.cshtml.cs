using Foodie.Models;
using Foodie.Pages.Recipes;
using Foodie.Services.EFServices;
using Foodie.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public IndexModel(ILogger<IndexModel> logger, IRecipeService recipeService, IRecipeItemService recipeItemService)
        {
            _logger = logger;
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
        }

        //[BindProperty] public SearchModel Search { get; set; } = new SearchModel();

        public void OnGet(string searchString)
        {
            
        }

        //public IActionResult OnPost()
        //{
        //    return RedirectToPage("/Recipes/GetAllRecipes", Search);
        //}
    }
}
