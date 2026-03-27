using System;
using System.Data.SqlClient;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data;

public class OrderRepository : IOrderRepository
{
    private readonly string _connectionString;

    public OrderRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Save(Order order)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(
            "INSERT INTO Orders(Customer, Product, Qty, Price) VALUES (@c, @p, @q, @pr); SELECT SCOPE_IDENTITY();",
            conn);

        cmd.Parameters.AddWithValue("@c", order.CustomerName);
        cmd.Parameters.AddWithValue("@p", order.ProductName);
        cmd.Parameters.AddWithValue("@q", order.Quantity);
        cmd.Parameters.AddWithValue("@pr", order.UnitPrice);

        conn.Open();

        var id = Convert.ToInt32(cmd.ExecuteScalar());
        order.SetId(id);
    }
}
