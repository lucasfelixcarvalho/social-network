using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IProfileRepository
{
    Profile? GetById(int id);
    List<Profile> GetByLocation(Location location);
    void Update(Profile profile);
    void Create(Profile profile);
}
