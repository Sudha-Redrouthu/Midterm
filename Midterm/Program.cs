using System;

public class InventoryItem
{
    // Properties are now private with public get methods, for better encapsulation
    public string ItemName { get; private set; }
    public int ItemId { get; private set; }
    public double Price { get; private set; }
    public int QuantityInStock { get; private set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // Validation and property initialization
        ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName), "Item name cannot be null.");
        ItemId = itemId;
        Price = price >= 0 ? price : throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        QuantityInStock = quantityInStock >= 0 ? quantityInStock : throw new ArgumentOutOfRangeException(nameof(quantityInStock), "Quantity cannot be negative.");
    }

    // Method to update the price
    public void UpdatePrice(double newPrice)
    {
        if (newPrice >= 0)
        {
            Price = newPrice;
            Console.WriteLine("Price updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid price. Price must not be negative.");
        }
    }

    // Method to restock the item
    public void RestockItem(int additionalQuantity)
    {
        if (additionalQuantity > 0)
        {
            QuantityInStock += additionalQuantity;
            Console.WriteLine("Item restocked successfully.");
        }
        else
        {
            Console.WriteLine("Invalid quantity. Restock amount must be positive.");
        }
    }

    // Method to sell the item
    public void SellItem(int quantitySold)
    {
        if (quantitySold > 0 && quantitySold <= QuantityInStock)
        {
            QuantityInStock -= quantitySold;
            Console.WriteLine("Item sold successfully.");
        }
        else
        {
            Console.WriteLine("Cannot sell. Either the quantity is negative or exceeds stock quantity.");
        }
    }

    // Method to check if the item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Method to print the details of the item
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, ID: {ItemId}, Price: {Price}, Stock Quantity: {QuantityInStock}");
    }
}


class Program
{
    static void Main()
    {
        // Initialize items
        InventoryItem laptop = new InventoryItem("Laptop", 101, 1200.5, 10);
        InventoryItem smartphone = new InventoryItem("Smartphone", 102, 800.3, 15);

        // Print initial details of items
        Console.WriteLine("Initial state of items:");
        laptop.PrintDetails();
        smartphone.PrintDetails();
        Console.WriteLine(); 

        // Update price of the laptop and print details
        Console.WriteLine("Updating the price of the laptop:");
        laptop.UpdatePrice(1000);
        laptop.PrintDetails();
        Console.WriteLine(); 

        // Sell laptops and print updated details
        Console.WriteLine("Selling laptops:");
        laptop.SellItem(3);
        laptop.PrintDetails();
        Console.WriteLine(); 

        // Restock smartphones and print updated details
        Console.WriteLine("Restocking smartphones:");
        smartphone.RestockItem(5);
        smartphone.PrintDetails();
        Console.WriteLine(); 

        // Check and print stock status for smartphones
        Console.WriteLine("Checking smartphone stock status:");
        Console.WriteLine(smartphone.IsInStock() ? "Smartphone is in stock." : "Smartphone is not in stock.");
        Console.WriteLine(); 
    }
}
