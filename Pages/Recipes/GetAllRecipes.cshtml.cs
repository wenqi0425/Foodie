using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Foodie.Services.EFServices;

namespace Foodie.Pages.Recipes
{
    public class GetAllRecipesModel : PageModel
    {
        //private IRecipeService _recipeService;
        //private IRecipeItemService _recipeItemService;

        //public GetAllRecipesModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
        //{
        //    _recipeService = recipeService;
        //    _recipeItemService = recipeItemService;
        //}

        private ISearchService _searchService;

        public GetAllRecipesModel(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IList<Recipe> Recipes { get; set; }
        public IList<RecipeItem> RecipeItems { get; set; }
        public string ScreenMessage { get; set; }     
        public SelectList SearchCategories { get; set; }

        //[BindProperty(SupportsGet = true)] public SearchModel Search { get; set; } = new SearchModel();
        [BindProperty(SupportsGet = true)] public string SearchCategory { get; set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public void OnGet() 
        {
            Recipes = _searchService.SearchRecipesByCriteria(SearchCategory, SearchString).ToList();
            if (Recipes.Count() == 0)
            {
                ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
            }
        }

        //public void OnGet()
        //{
        //    if (!string.IsNullOrEmpty(Search.SearchCategory) && Search.SearchCategory.Equals("Recipe"))
        //    {
        //        Recipes = _recipeService.SearchRecipes(Search.SearchString).ToList();
        //        if (Recipes.Count() == 0)
        //        {
        //            ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
        //        }
        //    }

        //    else if (!string.IsNullOrEmpty(Search.SearchCategory) && Search.SearchCategory.Equals("Ingredient"))
        //    {
        //        Recipes = _recipeItemService.SearchRecipes(Search.SearchString).ToList();
        //        if (Recipes.Count() == 0)
        //        {
        //            ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
        //        }
        //    }

        //    else
        //    {
        //        Recipes = _recipeService.GetAllRecipes().ToList();
        //    }
    }
}
