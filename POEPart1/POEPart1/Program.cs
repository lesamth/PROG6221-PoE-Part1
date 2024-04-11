using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace RecipeApplication
{
    //Student Number: ST10184582
    //Student Name: Palesa Mthimunye
    //PoE Part 1 
    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            // Variable to keep track of the number of recipes entered
            int recipeCount = 0;

            // Main loop for entering the recipes
            while (recipeCount < 5)
            {
                // Welcome message
                Console.WriteLine("Welcome to Recipe App!");
                Console.WriteLine("Enter 'done' at any time to exit the program.");
               
                // Prompting user to enter the name of the recipe
                Console.Write("Enter recipe name: ");
                string recipeName = Console.ReadLine();

                // Check if user wants to exit
                if (recipeName.ToLower() == "done")
                    break;

                // Create a new recipe object
                Recipe recipe = new Recipe(recipeName);
                // Enter recipe details
                recipe.EnterRecipeDetails();
                // Display entered recipe
                recipe.DisplayRecipe();

                // Scaling the recipe
                recipe.ScaleRecipe();

                recipeCount++;

                // Check if user wants to enter another recipe
                if (recipeCount < 5)
                {
                    Console.WriteLine("\nDo you want to enter another recipe? Enter 'yes' or 'no':");
                    string response = Console.ReadLine().ToLower();

                    if (response == "no")
                        break;
                    else if (response != "yes")
                    {
                        Console.WriteLine("Invalid input. Exiting program.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You have reached the maximum number of recipes allowed (5). Exiting program.");
                    break;
                }
            }
        }
    }

    // Recipe class to manage recipe details
    class Recipe
    {
        private string recipeName; // Name of the recipe
        private string[] ingredients; // Array to store ingredients
        private double[] quantities; // Array to store quantities of ingredients
        private string[] units; // Array to store units of measurement for ingredients
        private string[] steps; // Array to store recipe steps
        private double[] originalQuantities; // Array to store original quantities of ingredients

        // Constructor
        public Recipe(string name)
        {
            recipeName = name;
        }

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.WriteLine($"Enter the details for recipe '{recipeName}':");

            int numIngredients;
            // Loop to validate and get the number of ingredients
            while (true)
            {
                Console.WriteLine("Enter the number of ingredients:");
                if (int.TryParse(Console.ReadLine(), out numIngredients) && numIngredients > 0)
                    break;
                else
                    Console.WriteLine("Invalid input. Number of ingredients must be a positive integer.");
            }

            // Initialize arrays for ingredients, quantities, and units
            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Loop to input details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                ingredients[i] = ReadValidString(); // Input validation for ingredient name
                quantities[i] = ReadValidQuantity(); // Input validation for quantity
                Console.Write("Unit of measurement: ");
                units[i] = ReadValidUnit(); // Input validation for unit of measurement
            }

            // Copy original quantities for scaling
            originalQuantities = new double[numIngredients];
            Array.Copy(quantities, originalQuantities, numIngredients);

            int numSteps;
            // Loop to validate and get the number of steps
            while (true)
            {
                Console.WriteLine("Enter the number of steps:");
                if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
                    break;
                else
                    Console.WriteLine("Invalid input. Number of steps must be a positive integer.");
            }

            // Initialize array for steps
            steps = new string[numSteps];

            // Loop to input details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = ReadValidString(); // Input validation for step description
            }
        }

        // Method to display recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {recipeName}");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{ingredients[i]} - {quantities[i]} {units[i]}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to reset quantities to original values
        public void ResetQuantities()
        {
            Array.Copy(originalQuantities, quantities, originalQuantities.Length);
            Console.WriteLine("Recipe quantities reverted to original values.");
        }

        // Method to scale recipe quantities
        public void ScaleRecipe()
        {
            Console.WriteLine("Enter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            if (double.TryParse(Console.ReadLine(), out double scaleFactor))
            {
                if (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3)
                {
                    for (int i = 0; i < quantities.Length; i++)
                    {
                        quantities[i] *= scaleFactor;
                    }
                    Console.WriteLine($"Recipe scaled by a factor of {scaleFactor}");
                    DisplayRecipe();
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

        // Method for input validation of string
        private string ReadValidString()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && IsAlphaNumeric(input))
                    return input;
                else
                    Console.WriteLine("Invalid input. Please enter letters and numbers only.");
            }
        }

        // Method for input validation of quantity
        private double ReadValidQuantity()
        {
            double quantity;
            while (true)
            {
                Console.Write("Quantity: ");
                if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0 && quantity <= 10)
                    return quantity;
                else
                    Console.WriteLine("Invalid input. Quantity must be a positive number less than or equal to 10.");
            }
        }

        // Method for input validation of unit
        private string ReadValidUnit()
        {
            string unit;
            while (true)
            {
                Console.Write("Unit of measurement (cup/cups, teaspoon/teaspoons, tablespoon/tablespoons, box/boxes): ");
                unit = Console.ReadLine().ToLower();
                if (unit == "cup" || unit == "cups" || unit == "teaspoon" || unit == "teaspoons" ||
                    unit == "tablespoon" || unit == "tablespoons" || unit == "box" || unit == "boxes")
                    return unit;
                else
                    Console.WriteLine("Invalid input. Please enter one of the allowed unit measurements.");
            }
        }

        // Method to check if string is alphanumeric
        private bool IsAlphaNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }
    }
}


//The exeception for recipes input within the program
//1. After displaying a recipe, prompt the user if they want to enter a new recipe.
//2. Limit the number of recipes to five by keeping track of the number of recipes entered.
//3. Provide appropriate messages when the maximum number of recipes is reached.

//The exception for data and error handling 
//1. The ReadValidString() method is added to handle input validation for ingredient name, unit of measurement, and step description. It ensures that only letters and numbers are accepted.
//2. The ReadValidQuantity() method is added to handle input validation for quantity. It ensures that the quantity entered is a positive number less than or equal to 10.
//3. The IsAlphaNumeric() method is added to check whether a string contains only letters and numbers.
//4. Input validation is performed during the recipe entry process to ensure that only valid inputs are accepted.

//Other important factors within the code
//1. Input validation is implemented for the number of ingredients, quantity, scaling factor, and number of steps.
//2. Error messages are provided for invalid inputs.
//3. The program doesn't accept negative numbers for quantities or scaling factors.
//4. The user is prompted again until valid input is provided.

