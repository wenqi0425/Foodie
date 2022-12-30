#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Foodie.Models;

namespace Foodie.Models
{
    public class AppUser : IdentityUser<int>
    {
        // Email and PhoneNumber are members of the base class
        // and do not require a concrete implementation

        public override int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Postcode { get; set; }
        public string? AboutMe { get; set; }
    }
}
