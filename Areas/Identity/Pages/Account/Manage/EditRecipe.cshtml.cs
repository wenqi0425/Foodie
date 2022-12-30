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
using System.Linq;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    [BindProperties]
    public class EditRecipeModel : PageModel
    {
        public Recipe Recipe { get; set; }
        public AppUser AppUser { get; set; }
        public string Message { get; set; }

        public RecipeItem RecipeItem1 { get; set; }
        public RecipeItem RecipeItem2 { get; set; }
        public RecipeItem RecipeItem3 { get; set; }
        public RecipeItem RecipeItem4 { get; set; }
        public RecipeItem RecipeItem5 { get; set; }

        private UserManager<AppUser> _manager;
        private IRecipeService _recipeService;
        private IRecipeItemService _recipeItemService;

        public IEnumerable<RecipeItem> RecipeItemsOfOneRecipe { get; set; }

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

            RecipeItemsOfOneRecipe = _recipeItemService.GetRecipeItemsByRecipeId(recipeId);

            if (RecipeItemsOfOneRecipe.Count() != 0)
            {
                for (int i = 0; i < RecipeItemsOfOneRecipe.Count(); i++)
                {
                    if (i == 0) { RecipeItem1 = RecipeItemsOfOneRecipe.ElementAt(i); }
                    if (i == 1) { RecipeItem2 = RecipeItemsOfOneRecipe.ElementAt(i); }
                    if (i == 2) { RecipeItem3 = RecipeItemsOfOneRecipe.ElementAt(i); }
                    if (i == 3) { RecipeItem4 = RecipeItemsOfOneRecipe.ElementAt(i); }
                    if (i == 4) { RecipeItem5 = RecipeItemsOfOneRecipe.ElementAt(i); }
                }
            }

            return Page();
        }

        [HttpPost]
        public ActionResult OnPost()
        {
            // we need to keep some current recipe states.
            var recipeId = Recipe.Id;
            string tempImageFileString = null;
            byte[] bytes = null;

            // then we re-assign the Recipe and pointing it to existing Recipe. 
            var RecipeExisted = _recipeService.GetRecipeById(recipeId);

            // otherwise updating image by new uploading
            if (Recipe.ImageFile != null)
            {
                using (Stream s = Recipe.ImageFile.OpenReadStream())
                {
                    using (BinaryReader r = new BinaryReader(s))
                    {
                        bytes = r.ReadBytes((Int32)s.Length);
                    }
                }

                tempImageFileString = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            else
            {
                //  no mater saving ImageData
                tempImageFileString = RecipeExisted.ImageData;
            }

            // fetching existing recipeItems associated with current recipeId
            IEnumerable<RecipeItem> recipeItemsExisted = _recipeItemService.GetRecipeItemsByRecipeId(recipeId);

            // if existing item is zero, then we think client is creating a new recipe.
            // a recipe should have items size>0
            Boolean isNewRecipe = recipeItemsExisted.Count() == 0;

            if (isNewRecipe)
            {
                string[] itemNames = new string[] { RecipeItem1.Name, RecipeItem2.Name, RecipeItem3.Name, RecipeItem4.Name, RecipeItem5.Name };
                string[] amounts = new string[] { RecipeItem1.Amount, RecipeItem2.Amount, RecipeItem3.Amount, RecipeItem4.Amount, RecipeItem5.Amount };

                // populating 5 binding fields into RecipeItem List. 
                List<RecipeItem> recipeItemList = new List<RecipeItem>();

                for (int i = 0; i < itemNames.Length; i++)
                {
                    if (itemNames[i] != null && itemNames[i].Length > 0 && amounts[i] != null && amounts[i].Length > 0)
                    {
                        RecipeItem item = new RecipeItem();
                        item.Amount = amounts[i];
                        item.Name = itemNames[i];
                        item.RecipeId = Recipe.Id;
                        recipeItemList.Add(item);
                        _recipeItemService.AddRecipeItem(item);
                    }
                }

                Recipe.RecipeItems = recipeItemList;
            }
            else
            {
                List<RecipeItem> newItems = new List<RecipeItem>() { RecipeItem1, RecipeItem2, RecipeItem3, RecipeItem4, RecipeItem5 };
                updateRecipeItemNameAmount(new List<RecipeItem>(recipeItemsExisted), newItems, _recipeItemService);

                foreach (RecipeItem item in recipeItemsExisted)
                {
                    if (item.Name.Equals(RecipeItem1.Name)) { updateRecipeItemAmount(item, RecipeItem1, _recipeItemService); continue; }
                    if (item.Name.Equals(RecipeItem2.Name)) { updateRecipeItemAmount(item, RecipeItem2, _recipeItemService); continue; }
                    if (item.Name.Equals(RecipeItem3.Name)) { updateRecipeItemAmount(item, RecipeItem3, _recipeItemService); continue; }
                    if (item.Name.Equals(RecipeItem4.Name)) { updateRecipeItemAmount(item, RecipeItem4, _recipeItemService); continue; }
                    if (item.Name.Equals(RecipeItem5.Name)) { updateRecipeItemAmount(item, RecipeItem5, _recipeItemService); continue; }
                }

                // existed item names
                var itemNameExisted = recipeItemsExisted.Select(recipe => recipe.Name).ToList();
                // if found newly created items, then saving them
                newItems.ForEach(item => saveNewlyAddedItem(Recipe, item, itemNameExisted, _recipeItemService));
            }

            RecipeExisted.Name = Recipe.Name;
            RecipeExisted.Introduction = Recipe.Introduction;
            RecipeExisted.CookingSteps = Recipe.CookingSteps;
            RecipeExisted.ImageData = tempImageFileString;

            // recipe already in the DB, so update it.
            _recipeService.EditRecipe(RecipeExisted);
            return RedirectToPage("./CheckMyRecipes");
        }

        private void updateRecipeItemAmount(RecipeItem oldItem, RecipeItem newItem, IRecipeItemService recipeItemService)
        {
            oldItem.Name = newItem.Name;
            oldItem.Amount = newItem.Amount;
            recipeItemService.EditRecipeItem(oldItem);
        }

        private void saveNewlyAddedItem(Recipe recipe, RecipeItem recipeItem, List<string> itemNamesExisted, IRecipeItemService recipeItemService)
        {
            if (recipeItem != null && recipeItem.Name != null && recipeItem.Name.Length > 0 && !itemNamesExisted.Contains(recipeItem.Name))
            {
                RecipeItem item = new RecipeItem();
                item.Amount = recipeItem.Amount;
                item.Name = recipeItem.Name;
                item.RecipeId = Recipe.Id;
                recipeItemService.AddRecipeItem(item);
            }
        }

        private void updateRecipeItemNameAmount(List<RecipeItem> oldItems, List<RecipeItem> newItems, IRecipeItemService recipeItemService)
        {
            //newItems ref. to newly binded values; oldItems ref. to items fetched from db.
            // newItemsRefToPesisted in the new bindings
            List<RecipeItem> newItemsRefToPesisted = newItems.Take(oldItems.Count()).ToList();
            for (int i = 0; i < newItemsRefToPesisted.Count; i++)
            {
                // if both fields having been cleaned up, then delete this item from db.
                if (newItemsRefToPesisted[i].Name == null && newItemsRefToPesisted[i].Amount==null) { 
                    recipeItemService.DeleteRecipeItem(oldItems[i]); continue ; 
                }
                if (!newItemsRefToPesisted[i].Name.Equals(oldItems[i].Name))
                {
                    oldItems[i].Name = newItemsRefToPesisted[i].Name;
                    oldItems[i].Amount = newItemsRefToPesisted[i].Amount==null?"": newItemsRefToPesisted[i].Amount;
                    recipeItemService.EditRecipeItem(oldItems[i]);
                };
            }
        }
    }
}
