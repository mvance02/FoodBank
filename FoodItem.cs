using System;

public class FoodItem
{
    public string Name;
    public string Category;
    public int Quantity;
    public DateTime ExpirationDate;

    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
}

