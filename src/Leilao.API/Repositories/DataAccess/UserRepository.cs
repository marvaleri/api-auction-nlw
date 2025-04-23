using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly TheAuctionDbContext _dbContext;

    public UserRepository(TheAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(User => User.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
