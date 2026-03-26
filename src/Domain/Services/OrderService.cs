using Domain.Entities;
using System;
namespace Domain.Services;

public class OrderService
{
    public Order CreateOrder(string customer, string product, int qty, decimal price)
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(customer))
            throw new ArgumentException("Customer name is required");

        if (string.IsNullOrWhiteSpace(product))
            throw new ArgumentException("Product name is required");

        if (qty <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than 0");

        return new Order
        {
            // NO generar ID aquí
            CustomerName = customer,
            ProductName = product,
            Quantity = qty,
            UnitPrice = price
        };
    }
}
