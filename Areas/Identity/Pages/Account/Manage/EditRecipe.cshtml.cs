using Foodie.Models;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authorization;
using Foodie.Pages.Recipes;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    [BindProperties]
    public class EditRecipeModel : PageModel
    {
        public Recipe Recipe { get; set; }
        public AppUser AppUser { get; set; }
        public string Message { get; set; }

        public RecipeItem? RecipeItem1 { get; set; }
        public RecipeItem? RecipeItem2 { get; set; }
        public RecipeItem? RecipeItem3 { get; set; }
        public RecipeItem? RecipeItem4 { get; set; }
        public RecipeItem? RecipeItem5 { get; set; }

        private UserManager<AppUser> _manager;
        private IRecipeService _recipeService;

        public IRecipeItemService _recipeItemService;
        //public List<RecipeItem> RecipeItemsOfOneRecipe;

        AppDbContext _context;

        public EditRecipeModel(UserManager<AppUser> manager, IRecipeService recipeService,
            IRecipeItemService recipeItemService, AppDbContext context)
        {
            _recipeService = recipeService;
            _recipeItemService = recipeItemService;
            _manager = manager;
            _context = context;
        }
        public IActionResult OnGet(int recipeId)
        {
            Recipe = _recipeService.GetRecipeById(recipeId);
            if (Recipe == null)
            {
                return null;
            }
            return Page();
        }

        [HttpPost]
        public ActionResult OnPost()
        {
            var currentUserId = _manager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                return Page();
            }

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

            Recipe.UserId = Int32.Parse(currentUserId);
            var pesistedReceipe = _context.Recipes.Add(Recipe);
            _context.SaveChanges();

            /*
            Recipe.Name = name;
            Recipe.CookingSteps = cookingSteps;
            Recipe.Introduction= introduction;
            Recipe.ImageData = imageData;   */        

            /*RecipeItem.RecipeId = pesistedReceipe.Entity.Id;*/

            //List<string> Ingredients = new List<string>(){ ingredient1, ingredient2, ingredient3, ingredient4, ingredient5 };
            //List<string> Amounts = new List<string>() { amount1, amount2, amount3, amount4, amount5};

            // populating 5 items value into RecipeItem List. 
            string[] ingredients = new string[] { RecipeItem1.Name, RecipeItem2.Name, RecipeItem3.Name, RecipeItem4.Name, RecipeItem5.Name };
            string[] amounts = new string[] { RecipeItem1.Amount, RecipeItem2.Amount, RecipeItem3.Amount, RecipeItem4.Amount, RecipeItem5.Amount };
            List<RecipeItem> recipeItemList = new List<RecipeItem>(); 

            for (int i = 0; i < ingredients.Length; i++) {
                if (ingredients[i] != null && ingredients[i].Length > 0) {
                    if (amounts[i] != null && amounts[i].Length > 0) {
                        var item = new RecipeItem();
                        item.Amount = amounts[i];
                        item.Name = ingredients[i];
                        item.RecipeId = Recipe.Id;
                        recipeItemList.Add(item);
                        _recipeItemService.AddRecipeItem(item);                        
                    }
                }
            }

            Recipe.RecipeItems = recipeItemList;
            _recipeService.EditRecipe(Recipe);
            return RedirectToPage("./CheckMyRecipes");
        }
    }
}
