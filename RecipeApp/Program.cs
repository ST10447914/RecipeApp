using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}";
        }
    }

    class Recipe
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Recipe recipe = new Recipe();

            Console.Write("Enter the number of ingredients: ");
            if (!int.TryParse(Console.ReadLine(), out int numIngredients) || numIngredients < 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of ingredients.");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity for {name}: ");
                if (!double.TryParse(Console.ReadLine(), out double quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive number.");
                    return;
                }

                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(new Ingredient(name, quantity, unit));
            }

            Console.Write("Enter the number of steps: ");
            if (!int.TryParse(Console.ReadLine(), out int numSteps) || numSteps < 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of steps.");
                return;
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipe.DisplayRecipe();
        }
    }
}
