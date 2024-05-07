using Domain.Entities;
using Domain.Repositories;
using Persistence.DbContexts;

namespace Persistence.Repositories;

public class AccountRepository(SocialNetworkDbContext dbContext) : IAccountRepository
{
    private readonly SocialNetworkDbContext _dbContext = dbContext;

    public Account? GetById(int id)
    {
        return _dbContext.Accounts.SingleOrDefault(x => x.Id == id);
    }

    public Account? GetByLoginAndHash(string email, string hash)
    {
        return _dbContext.Accounts.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(hash));
    }

    public void Insert(Account account)
    {
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();
    }

    public void Update(Account account)
    {
        _dbContext.Accounts.Update(account);
        _dbContext.SaveChanges();
    }
}
