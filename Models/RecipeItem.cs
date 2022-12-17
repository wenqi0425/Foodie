using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Foodie.Models
{
    public class RecipeItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingredient Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Amount:")]
        public string Amount { get; set; }

        // Foreign Keys
        public int RecipeId { get; set; }

        // Navigation Properties
        public Recipe Recipe { get; set; }
    }
}
