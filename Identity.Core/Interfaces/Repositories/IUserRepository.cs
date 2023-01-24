using Identity.Core.Entities;

namespace Identity.Core.Interfaces.Repositories;

public interface IUserRepository
{
    List<User?> GetAll();
    void Add(User user);
    User? GetByUserName(string login);
    User? GetById(string id);
}