using Domain.Entities;

namespace Domain.Repositories;

public interface IConnectionRepository
{
    void Follow(Connection connection);
    void Unfollow(Connection connection);
}
