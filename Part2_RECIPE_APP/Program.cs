using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_RECIPE_APP
{
   
    public class Program
    {
        static void Main()
        {
            List<Recipe> recipeCollection = new List<Recipe>();

            Console.WriteLine("Welcome to the Recipe Application!");

            while (true)
            {
                Console.WriteLine("\nEnter 'a' to add a recipe");
                Console.WriteLine("Enter 'd' to display recipes");
                Console.WriteLine("Enter 'q' to quit");
                Console.WriteLine("----------------------------");
                Console.Write("Please enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "a":
                        AddRecipe(recipeCollection);
                        break;
                    case "d":
                        DisplayRecipes(recipeCollection);
                        break;
                    case "q":
                       //exit
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to add a recipe
        static void AddRecipe(List<Recipe> recipeCollection)
        {
            Console.WriteLine("\nAdding a Recipe");

            Console.Write("Enter recipe name: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe();
            recipe.Rec_Name = recipeName;
            recipe.Ingredients = new List<RecipeIngredient>();

            while (true)
            {
                Console.WriteLine("\nEnter ingredient details (or 'done' to finish):");

                Console.Write("Ingredient name: ");
                string ingredientName = Console.ReadLine();

                if (ingredientName.ToLower() == "done")
                    break;

                Console.Write("Number of calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter food group:");
                Console.WriteLine("1. Grains");
                Console.WriteLine("2. Fruits");
                Console.WriteLine("3. Vegetables");
                Console.WriteLine("4. Dairy");
                Console.WriteLine("5. Protein");
                Console.Write("Select food group (1-5): ");
                int foodGroupChoice = int.Parse(Console.ReadLine());

                FoodGroup foodGroup = (FoodGroup)(foodGroupChoice - 1);

                RecipeIngredient ingredient = new RecipeIngredient();
                ingredient.Ingre_Name = ingredientName;
                ingredient.Ingre_Calories = calories;
                ingredient.Group = foodGroup;

                recipe.AddIngredient(ingredient);
            }

            recipeCollection.Add(recipe);

            Console.WriteLine("Recipe added successfully!");
        }

        // Method to display recipes
        static void DisplayRecipes(List<Recipe> recipeCollection)
        {
            Console.WriteLine("\nRecipes:");

            if (recipeCollection.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                for (int i = 0; i < recipeCollection.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipeCollection[i].Rec_Name}");
                }

                Console.Write("Enter the number of the recipe to display details: ");
                int recipeIndex = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                if (recipeIndex >= 1 && recipeIndex <= recipeCollection.Count)
                {
                    Recipe selectedRecipe = recipeCollection[recipeIndex - 1];

                    Console.WriteLine($"\nRecipe: {selectedRecipe.Rec_Name}");
                    Console.WriteLine("Ingredients:");

                    foreach (RecipeIngredient ingredient in selectedRecipe.Ingredients)
                    {
                        Console.WriteLine($"- {ingredient.Ingre_Name} ({ingredient.Ingre_Calories} calories) - {ingredient.Group}");
                    }

                    int totalCalories = selectedRecipe.CalculateTotalCalories();
                    Console.WriteLine("Total Calories: " + totalCalories);

                    // Notify the user if the total calories exceed 300
                    if (totalCalories > 300)
                    {
                        Console.WriteLine("WARNING: This recipe exceeds 300 calories!");
                    }
                    Console.WriteLine("----------------------------");
                }
                else
                {
                    Console.WriteLine("Invalid recipe number.");
                }
            }
        }
    }

}
