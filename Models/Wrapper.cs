using Foodie.Models;

namespace Foodie.Models
{
    // Another effort I try to edit the content of two tables in one page, but it doesn't work. Therefore I have to change the UI design. 
    // It is the limitation of RazorPage Framework. I discuss it in my report. 
    public class Wrapper
    {
        public int WrapperId { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeItem RecipeItem { get; set; }
    }
}
