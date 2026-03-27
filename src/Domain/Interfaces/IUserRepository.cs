public interface IUserRepository
{
    IEnumerable<string> GetByName(string name);
}
