using System;
using Domain.Entities;

namespace Domain.Services;

public static class OrderService
{
    public static Order CreateOrder(string customer, string product, int qty, decimal price)
    {
        if (string.IsNullOrWhiteSpace(customer))
            throw new ArgumentException("Customer is required");

        if (string.IsNullOrWhiteSpace(product))
            throw new ArgumentException("Product is required");

        if (qty <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        return new Order(customer, product, qty, price); // 
    }
}
