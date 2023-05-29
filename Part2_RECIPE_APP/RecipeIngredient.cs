using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_RECIPE_APP
{
    //ingredients that are stored to a recipe
    public class RecipeIngredient
    {
        public string Ingre_Name { get; set; }
        public int Ingre_Calories { get; set; }
        public FoodGroup Group { get; set; }
    } // Enum for food groups
   public enum FoodGroup
    {
        Grains,
        Fruits,
        Vegetables,
        Dairy,
        Protein
    }

}
