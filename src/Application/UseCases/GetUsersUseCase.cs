using Domain.Interfaces;
using System.Collections.Generic;

public class Aplication.UseCases
{
    private readonly IUserRepository _repo;

    public GetUsersUseCase(IUserRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<string> Execute(string name)
    {
        return _repo.GetByName(name);
    }
}
