using System.Collections.Generic;

namespace Domain.Interfaces
{
public interface IUserRepository
{
    IEnumerable<string> GetByName(string name);
}
}
