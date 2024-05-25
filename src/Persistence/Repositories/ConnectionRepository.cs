using Domain.Entities;
using Domain.Repositories;
using Persistence.DbContexts;

namespace Persistence.Repositories;

public class ConnectionRepository(SocialNetworkDbContext dbContext) : IConnectionRepository
{
    private readonly SocialNetworkDbContext _dbContext = dbContext;

    public void Follow(Connection connection)
    {
        _dbContext.Connections.Add(connection);
        _dbContext.SaveChanges();
    }

    public void Unfollow(Connection connection)
    {
        _dbContext.Connections.Remove(connection);
        _dbContext.SaveChanges();
    }
}
