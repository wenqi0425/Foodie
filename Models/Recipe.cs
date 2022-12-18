using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Foodie.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Recipe Name:")]
        public string Name { get; set; }
        
        /*
        [Required]
        [Display(Name = "Recipe Items:")]
        public ICollection<RecipeItem> RecipeItems { get; set; }*/

        [Display(Name = "Cooking Steps:")]
        public string CookingSteps { get; set; }        

        [Display(Name = "Introduction:")]
        public string? Introduction { get; set; }

        [Display(Name = "Image:")]
        public string ImageData { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        // Foreign Keys
        public int UserId { get; set; }

        // Navigation Properties
        public AppUser User { get; set; }
    }
}
