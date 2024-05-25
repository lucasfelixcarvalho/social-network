using Domain.Entities;

namespace Domain.Repositories;

public interface IPostRepository
{
    void Insert(Post post);
    void Delete(Post post);
    void Update(Post post);
    List<Post> GetByProfileId(int profileId);
    Post? GetById(int id);
}
