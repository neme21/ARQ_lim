namespace Domain.Interfaces
using System.Collections.Generic;
{
public interface IUserRepository
{
    IEnumerable<string> GetByName(string name);
}
}
