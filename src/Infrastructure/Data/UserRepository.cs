using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<string> GetByName(string name)
    {
        var result = new List<string>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT name FROM Users WHERE name = @name", conn);

        cmd.Parameters.AddWithValue("@name", name); 

        conn.Open();
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            result.Add(reader.GetString(0));
        }

        return result;
    }
}
