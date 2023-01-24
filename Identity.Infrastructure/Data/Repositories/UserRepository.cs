using Identity.Core.Entities;
using Identity.Core.Interfaces.Repositories;

namespace Identity.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ISqlServerRepository<User?> _userRepository;

    public UserRepository(ISqlServerRepository<User?> userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User?> GetAll()
    {
        return _userRepository.Find().ToList();
    }

    public void Add(User user)
    {
        _userRepository.Add(user);
    }

    public User? GetByUserName(string username)
    {
        User? user = _userRepository.Get(u => u.UserName == username);
        return user;
    }

    public User? GetById(string id)
    {
        return _userRepository.GetById(id);
    }
}