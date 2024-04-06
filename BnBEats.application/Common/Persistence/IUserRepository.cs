using BnBEats.domain;

namespace BnBEats.application;

public interface IUserRepository
{

    public User? GetUserByEmail (string Email);
    public void AddUser (User user);
}
