
namespace Domain.Services;

using Domain.Entities;

public static class OrderService
{
    public static Order CreateTerribleOrder(string customer, string product, int qty, decimal price)
    {
        return new Order
        {
            Id = new Random().Next(1, 1000),
            CustomerName = customer,
            ProductName = product,
            Quantity = qty,
            UnitPrice = price
        };
    }
}
