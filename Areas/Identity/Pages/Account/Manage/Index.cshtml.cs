using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Foodie.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Foodie.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }
        public AppUser LoggedInUser { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty] public string FirstName { get; set; }
        [BindProperty] public string LastName { get; set; }        
        [BindProperty] public string Address { get; set; }
        [BindProperty] public string Postcode { get; set; }
        [BindProperty] public string AboutMe { get; set; }
        [BindProperty] public string PhoneNumber { get; set; }

        [BindProperty] public InputModel Input { get; set; }
        public class InputModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Postcode { get; set; }
            public string AboutMe { get; set; }
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            LoggedInUser = await _userManager.GetUserAsync(User);

            Username = userName;

            PhoneNumber = user.PhoneNumber;               
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            Postcode = user.Postcode;
            AboutMe = user.AboutMe;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.AboutMe = AboutMe;
            user.Address = Address;
            user.Postcode = Postcode;
            user.PhoneNumber = PhoneNumber;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
