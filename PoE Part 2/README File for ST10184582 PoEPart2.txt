# PROG6221-PoE-Part2

# Recipe Application
# Description:
The Recipe Application is a console-based program written in C# that allows users to manage recipes. It provides functionalities to create, store, and display recipes along with their ingredients and steps.

## Features:
1.Recipe Management: Users can enter details for multiple recipes, including their names, ingredients, quantities, units, calories, food groups, and steps.
2.	Ingredient Management: Each recipe can have multiple ingredients with associated details such as quantity, unit, calories, and food group.
3.	User Interaction: The application interacts with users through the console, guiding them to input recipe details and providing options to view recipes.
4.	Recipe Sorting: Recipes are sorted alphabetically by name for easy access and organization.
5.	Clear Console: The application clears the console to maintain a clean and organized user interface.
6.	Data Validation: Basic input validation ensures that users provide valid input for quantities, calories, and other details.
7.	File Reading: The application does not currently include file reading functionality.
8.	Error Handling and Input Validation: The program incorporates error handling and input validation to ensure that users provide valid input for quantities, calories, and other details.
9.	Exception Handling: Exception handling is implemented to gracefully handle runtime errors and prevent program crashes.

## How to Use
1.	**Running the Application:**
•	Compile and run the application in a C# environment such as Visual Studio or using the .NET Core CLI.
•	Follow the prompts to enter recipe details, including name, ingredients, quantities, units, calories, food groups, and steps.
•	After entering recipes, the application displays a list of recipes sorted alphabetically by name.
•	Select a recipe to view its details, including ingredients and steps.
2.	**Customization:**
•	Users can extend the application by adding features such as file reading and writing to store recipes in external files.
•	Additional functionalities, such as editing and deleting recipes, can be implemented to enhance user experience.

## Error Handling and Input Validation:
•	The application incorporates error handling and input validation mechanisms to ensure that users provide correct and valid data.
•	Input validation is performed for quantities, calories, and other details to prevent invalid entries.
•	Error messages are displayed to guide users when incorrect inputs are detected.

## Exception Handling:
•	Exception handling is implemented to gracefully handle runtime errors and prevent program crashes.
•	Try-catch blocks are used to catch exceptions and handle them appropriately, ensuring the stability of the application.

## What I have changed based on my lecturers’ feedback 
I have ensured that the following: 
•	Clear Functionality: A clear function was added to clear the console before displaying a recipe, ensuring a neat and organized display format.
•	Improved Display Format: The program now prompts the user to enter one recipe at a time, ensuring a clearer and more organized user experience. Additionally, the recipes are displayed in a sorted order, improving readability.
•	Limited Scaling Factor: The scaling factor for recipes was restricted to only allow values of 0.5, 2, or 3, as per the lecturer's recommendation. This ensures that the scaling is consistent and avoids potential issues with arbitrary scaling factors.
•	Separated Classes: The classes (Program, Recipe, and Ingredient) were separated into their own files, enhancing code organization and maintainability. Each class now resides in its own file, adhering to the principle of single responsibility.

Link to the GitHub Repository: https://github.com/lesamth/PROG6221-PoE-Part1.git

## About the Author:
- **Student Number:** ST10184582
- **Student Name:** Palesa Mthimunye
- **PoE Part 2**

