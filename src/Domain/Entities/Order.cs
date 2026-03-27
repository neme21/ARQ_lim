using System;

namespace Domain.Entities;

public class Order
{
    public int Id { get; private set; } 
    public string CustomerName { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public Order(string customerName, string productName, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name is required");

        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Product name is required");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than 0");

        CustomerName = customerName;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public decimal CalculateTotal()
    {
        return Quantity * UnitPrice;
    }
    
    public void SetId(int id)
    {
        Id = id;
    }
}
