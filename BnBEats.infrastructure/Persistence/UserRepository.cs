using BnBEats.application;
using BnBEats.domain;

namespace BnBEats.infrastructure;

public class UserRepository : IUserRepository
{
    private readonly List<User> users = new List<User>();

    public void AddUser(User user)
    {
        
        users.Add(user);
    }

    public User? GetUserByEmail(string Email)
    {
        return users.SingleOrDefault(user => user.Email == Email);
    }
}
