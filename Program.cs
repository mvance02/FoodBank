using System;
using System.Collections.Generic;

List<FoodItem> inventory = new List<FoodItem>();
bool running = true;

Console.WriteLine("Food Bank Inventory System");

while (running)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Add Food Item");
    Console.WriteLine("2. Delete Food Item");
    Console.WriteLine("3. Print Current Food Items");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine() ?? "";

    if (choice == "1")
        AddFoodItem(inventory);
    else if (choice == "2")
        DeleteFoodItem(inventory);
    else if (choice == "3")
        PrintFoodItems(inventory);
    else if (choice == "4")
    {
        running = false;
        Console.WriteLine("Goodbye!");
    }
    else
        Console.WriteLine("Invalid choice. Please try again.");
}

void AddFoodItem(List<FoodItem> inventory)
{
    Console.Write("Enter food name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Enter category: ");
    string category = Console.ReadLine() ?? "";

    Console.Write("Enter quantity: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    Console.Write("Enter expiration date (yyyy-mm-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
    {
        Console.WriteLine("Invalid date format.");
        return;
    }

    FoodItem item = new FoodItem(name, category, quantity, expirationDate);
    inventory.Add(item);

    Console.WriteLine("Food item added successfully.");
}

void DeleteFoodItem(List<FoodItem> inventory)
{
    if (inventory.Count == 0)
    {
        Console.WriteLine("No items to delete.");
        return;
    }

    for (int i = 0; i < inventory.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {inventory[i].Name} | Qty: {inventory[i].Quantity} | Expires: {inventory[i].ExpirationDate.ToShortDateString()}");
    }

    Console.Write("Enter the number of the item to delete: ");
    if (!int.TryParse(Console.ReadLine(), out int index) ||
        index < 1 || index > inventory.Count)
    {
        Console.WriteLine("Invalid selection.");
        return;
    }

    inventory.RemoveAt(index - 1);
    Console.WriteLine("Item removed.");
}

void PrintFoodItems(List<FoodItem> inventory)
{
    if (inventory.Count == 0)
    {
        Console.WriteLine("No food items in inventory.");
        return;
    }

    foreach (FoodItem item in inventory)
    {
        Console.WriteLine($"{item.Name} | {item.Category} | Qty: {item.Quantity} | Expires: {item.ExpirationDate.ToShortDateString()}");
    }
}







