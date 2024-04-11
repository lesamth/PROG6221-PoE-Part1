# PROG6221-PoE-Part1
This is the submission for the module of programming, PROG6221 PoE Part 1

# Recipe Application

This application allows users to enter, display, and scale recipes. It provides a simple interface for entering recipe details such as ingredients, quantities, units, and steps. Users can enter multiple recipes, and each recipe can have up to 5 ingredients and steps.

## How to Use

1. **Running the Program**
   - The program is written in C# and can be compiled and executed using a C# compiler or an integrated development environment (IDE) such as Visual Studio.
   - After running the program, the user will be prompted to enter recipe details.

2. **Entering Recipes**
   - The user can enter the name of the recipe, followed by details for each ingredient and step.
   - Input validation is performed for ingredient names, quantities, units, and step descriptions to ensure only valid inputs are accepted.
   - The user can enter up to 5 recipes. After displaying a recipe, the user is prompted if they want to enter another recipe. If the maximum number of recipes is reached, appropriate messages are displayed.

3. **Scaling Recipes**
   - After entering a recipe, the user has the option to scale the recipe by a factor of 0.5 (half), 2 (double), or 3 (triple).
   - Scaling factors are validated to ensure only valid inputs are accepted.
   - The program displays the scaled recipe with updated quantities.

4. **Exiting the Program**
   - At any point, the user can enter 'done' to exit the program.

## Error Handling and Input Validation

- The program includes input validation for various user inputs such as ingredient names, quantities, units, scaling factors, and step descriptions.
- Error messages are provided for invalid inputs, and the user is prompted to enter valid inputs until satisfactory input is provided.
- The program does not accept negative numbers for quantities or scaling factors.

## Exception Handling

- The program limits the number of recipes to five by keeping track of the number of recipes entered. Appropriate messages are displayed when the maximum number of recipes is reached.
- Input validation is performed during the recipe entry process to ensure that only valid inputs are accepted.
- The program handles exceptions gracefully and provides clear instructions to the user.

## About the Author

- **Student Number:** ST10184582
- **Student Name:** Palesa Mthimunye
- **PoE Part 1**

