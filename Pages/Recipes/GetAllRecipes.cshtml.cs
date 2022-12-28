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
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public GetAllRecipesModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
        }

        public IList<Recipe> Recipes { get; set; }
        public IList<RecipeItem> RecipeItems { get; set; }
        public string ScreenMessage { get; set; }
        //[BindProperty(SupportsGet = true)] public string SearchItem { get; set; }
        //[BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public SelectList SearchItems { get; set; }

        [BindProperty(SupportsGet = true)] public SearchModel Search { get; set; } = new SearchModel();

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(Search.SearchItem) && Search.SearchItem.Equals("Recipe"))
            {
                Recipes = _recipeService.SearchRecipes(Search.SearchString).ToList();
                if (Recipes.Count() == 0)
                {
                    ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
                }
            }

            else if (!string.IsNullOrEmpty(Search.SearchItem) && Search.SearchItem.Equals("Ingredient"))
            {
                Recipes = _recipeItemService.SearchRecipes(Search.SearchString).ToList();
                if (Recipes.Count() == 0)
                {
                    ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
                }
            }

            else
            {
                Recipes = _recipeService.GetAllRecipes().ToList();
            }

            //if (!string.IsNullOrEmpty(Search.RecipeName) )
            //{
            //    Recipes = _recipeService.SearchRecipes(Search.RecipeName).ToList();
            //    if (Recipes.Count() == 0)
            //    {
            //        ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
            //    }
            //}
            //else
            //{
            //    Recipes = _recipeService.GetAllRecipes().ToList();
            //}
        }
    }

    // Don't Repeat Yourself: SearchModel will be reused at the Index Page
    public class SearchModel
    {
        public string SearchItem { get; set; }
        public string SearchString { get; set; }
        //public IList<Recipe> Recipes { get; set; }
        //public IList<RecipeItem> RecipeItems { get; set; }

        //private IRecipeService _recipeService;
        //private IRecipeItemService _recipeItemService;

        //public string ScreenMessage { get; set; }

        //public SearchModel(IRecipeService recipeService, IRecipeItemService recipeItemService)
        //{
        //    _recipeService = recipeService;
        //    _recipeItemService = recipeItemService;
        //}

        //public IEnumerable<Recipe> SearchRecipes(string searchString)
        //{
        //    if (!string.IsNullOrEmpty(SearchItem) && SearchItem.Equals("Recipe"))
        //    {
        //        Recipes = _recipeService.SearchRecipes(Search.SearchString).ToList();
        //        if (Recipes.Count() == 0)
        //        {
        //            ScreenMessage = "Sorry! We couldn't match any recipes to your request.";
        //        }
        //    }

        //    else if (!string.IsNullOrEmpty(Search.SearchItem) && Search.SearchItem.Equals("Ingredient"))
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
        //}
    }
}
