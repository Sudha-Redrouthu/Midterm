using System;

public class InventoryItem
{
    public string ItemName { get; private set; }
    public int ItemId { get; private set; }
    public double Price { get; private set; }
    public int QuantityInStock { get; private set; }

    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative.");
        QuantityInStock = quantityInStock >= 0 ? quantityInStock : throw new ArgumentException("Quantity cannot be negative.");
    }

    public void UpdatePrice()
    {
        Console.WriteLine($"Enter the new price for {ItemName}:");
        if (double.TryParse(Console.ReadLine(), out double updatedPrice) && updatedPrice >= 0)
        {
            Price = updatedPrice;
            Console.WriteLine("Price updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid price entered. Price update failed.");
        }
    }

    public void RestockItem(int additionalQuantity)
    {
        if (additionalQuantity > 0)
        {
            QuantityInStock += additionalQuantity;
        }
        else
        {
            Console.WriteLine("Invalid restock quantity. Operation failed.");
        }
    }

    public void SellItem(int quantitySold)
    {
        if (quantitySold > 0 && quantitySold <= QuantityInStock)
        {
            QuantityInStock -= quantitySold;
        }
        else
        {
            Console.WriteLine("Cannot complete the sale due to insufficient stock or invalid quantity.");
        }
    }

    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, ID: {ItemId}, Price: {Price}, Stock Quantity: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        item1.PrintDetails();
        item2.PrintDetails();

        item1.UpdatePrice(); // Get new price from user
        item1.SellItem(3);
        item1.PrintDetails();

        item2.RestockItem(5);
        item2.PrintDetails();

        if (item1.IsInStock())
        {
            Console.WriteLine($"{item1.ItemName} is in stock.");
        }
        else
        {
            Console.WriteLine($"{item1.ItemName} is not in stock.");
        }
    }
}
