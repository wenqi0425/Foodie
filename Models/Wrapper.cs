using Foodie.Models;

namespace Foodie.Models
{
    public class Wrapper
    {
        public int WrapperId { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeItem RecipeItem { get; set; }
    }
}
