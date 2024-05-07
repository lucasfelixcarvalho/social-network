using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Persistence.DbContexts;

namespace Persistence.Repositories;

public class ProfileRepository(SocialNetworkDbContext dbContext) : IProfileRepository
{
    private readonly SocialNetworkDbContext _dbContext = dbContext;

    public Profile? GetById(int id)
    {
        return _dbContext.Profiles.SingleOrDefault(p => p.Id == id);
    }

    public List<Profile> GetByLocation(Location location)
    {
        return _dbContext.Profiles.Where(p => p.Location == location).ToList();
    }

    public void Update(Profile profile)
    {
        _dbContext.Profiles.Update(profile);
        _dbContext.SaveChanges();
    }
}
