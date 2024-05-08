using Domain.Entities;
using Domain.Repositories;
using Persistence.DbContexts;

namespace Persistence.Repositories;

public class PostRepository(SocialNetworkDbContext dbContext) : IPostRepository
{
    private readonly SocialNetworkDbContext _dbContext = dbContext;

    public void Delete(Post post)
    {
        _dbContext.Posts.Remove(post);
        _dbContext.SaveChanges();
    }

    public Post? GetById(int id)
    {
        return _dbContext.Posts.SingleOrDefault(p => p.Id == id);
    }

    public List<Post> GetByProfileId(int profileId)
    {
        return _dbContext.Posts.Where(p => p.ProfileId == profileId).OrderByDescending(p => p.PublishedAt).ToList();
    }

    public void Insert(Post post)
    {
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
    }

    public void Update(Post post)
    {
        _dbContext.Posts.Update(post);
        _dbContext.SaveChanges();
    }
}
