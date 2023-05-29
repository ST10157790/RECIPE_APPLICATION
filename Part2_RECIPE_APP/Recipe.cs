using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_RECIPE_APP
{
    // Delegate to notify the user when a recipe exceeds 300 calories
   public  delegate void RecipeExceedsCaloriesNotification(string recipeName, int totalCalories);
    public class Recipe
    {
        public string Rec_Name { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }

        // Event to trigger the notification when total calories exceed 300
        public event RecipeExceedsCaloriesNotification RecipeExceedsCalories;

        // Method to calculate total calories of the recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(ingredient => ingredient.Ingre_Calories);
            return totalCalories;
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(RecipeIngredient ingredient)
        {
            Ingredients.Add(ingredient);
            int totalCalories = CalculateTotalCalories();

            // Check if total calories exceed 300 and trigger the notification event
            if (totalCalories > 300)
            {
                RecipeExceedsCalories?.Invoke(Rec_Name, totalCalories);
            }
        }
    }
}
