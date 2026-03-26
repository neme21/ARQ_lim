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
        Id = new Random().Next(1, 1000); // luego mejoramos esto
        CustomerName = customerName;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public decimal CalculateTotal()
    {
        return Quantity * UnitPrice;
    }
}
