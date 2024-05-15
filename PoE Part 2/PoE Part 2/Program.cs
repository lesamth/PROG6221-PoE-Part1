using System;
using System.Collections.Generic;
using System.Linq;
//Student Number: ST10184582
//Student Name: Palesa Mthimunye
//PoE Part 2

namespace PoE_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store recipes entered by the user
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("Welcome to Recipe App!");
                Console.WriteLine("Enter 'done' at any time to exit the program.");
                Console.WriteLine("Enter 'list' to display all recipes.");

                // Check if there are already recipes entered
                if (recipes.Any())
                {
                    Console.WriteLine("Do you want to enter another recipe? Enter 'yes' or 'no':");
                    string response = Console.ReadLine().ToLower();

                    if (response == "no")
                        break;
                    else if (response != "yes")
                    {
                        Console.WriteLine("Invalid input. Exiting program.");
                        break;
                    }
                }



                // Prompt for recipe name
                Console.Write("Enter recipe name: ");
                string recipeName = Console.ReadLine();

                // Check if the user wants to exit or display the recipe list
                if (recipeName.ToLower() == "done")
                    break;
                else if (recipeName.ToLower() == "list")
                {
                    DisplayRecipeList(recipes);
                    continue;
                }

                // Create a new recipe instance
                Recipe recipe = new Recipe(recipeName);
                // Enter details for the recipe
                recipe.EnterRecipeDetails();
                // Add the recipe to the list
                recipes.Add(recipe);


                Console.WriteLine("Recipe added successfully!");

                // Subscribe to the event to handle exceeding calories notification
                recipe.NotifyExceedingCalories += (sender, calories) =>
                {
                    Console.WriteLine($"Warning: {recipe.Name} has exceeded 300 calories!");
                };

                // Ask if the user wants to scale the recipe
                Console.WriteLine("Do you want to scale this recipe? Enter 'yes' or 'no':");
                string scaleResponse = Console.ReadLine().ToLower();
                if (scaleResponse == "yes")
                {
                    recipe.ScaleRecipe();
                    recipe.DisplayRecipe(); //Display the recipe after scaling
                }
            }

            // Sort recipes by name
            recipes.Sort((x, y) => string.Compare(x.Name, y.Name));

            // Display all recipes
            DisplayRecipeList(recipes);

            // Choose a recipe to display details
            Console.WriteLine("Enter the number of the recipe you want to display:");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[choice - 1];
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        // Method to display list of recipes
        static void DisplayRecipeList(List<Recipe> recipes)
        {
            Console.WriteLine("\nRecipe List:");
            // Sort recipes by name before displaying
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.WriteLine();
        }
    }

    // Class representing a Recipe
    internal class Recipe
    {
        // Properties
        public string Name { get; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        // Event to notify exceeding calories
        public event EventHandler<int> NotifyExceedingCalories;

        // Constructor
        public Recipe(string name)
        {
            Name = name;
        }

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.WriteLine($"Enter the details for recipe '{Name}':");

            // Enter ingredients
            while (true)
            {
                Console.WriteLine("Enter ingredient details or 'done' to finish:");
                Console.Write("Ingredient name: ");
                string ingredientName = Console.ReadLine();
                if (ingredientName.ToLower() == "done")
                    break;

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();


                Console.Write("Number of calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Food group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            // Enter cooking steps
    int numSteps;
    while (true)
    {
        Console.WriteLine("Enter the number of steps:");
        if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
            break;
        else
            Console.WriteLine("Invalid input. Number of steps must be a positive integer.");
    }

    steps.Clear(); // Clear previous steps if any

    for (int i = 0; i < numSteps; i++)
    {
        Console.WriteLine($"Enter step {i + 1}:");
        steps.Add(Console.ReadLine());
    }

            // Calculate total calories of the recipe
            CalculateTotalCalories();
        }

        // Method to calculate total calories
        private void CalculateTotalCalories()
        {
            int totalCalories = ingredients.Sum(i => i.Calories);
            if (totalCalories > 300)
                NotifyExceedingCalories?.Invoke(this, totalCalories);
        }

        // Method to display recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            }
            Console.WriteLine("\nSteps:");
            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            Console.WriteLine("Enter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            if (double.TryParse(Console.ReadLine(), out double scaleFactor))
            {
                if (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3)
                {
                    foreach (var ingredient in ingredients)
                    {
                        ingredient.Quantity *= scaleFactor;
                        ingredient.Calories = (int)Math.Round(ingredient.Calories * scaleFactor);
                    }
                    Console.WriteLine($"Recipe scaled by a factor of {scaleFactor}");
                }
                else
                {
                    Console.WriteLine("Invalid scaling factor.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for scaling factor.");
            }
        }
    }

    // Class representing an Ingredient
    internal class Ingredient
    {
        // Properties
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public int Calories { get; set; }
        public string FoodGroup { get; }

        // Constructor
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // ClearConsole function definition
        private static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
