using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories;

public interface IProfileRepository
{
    void Update(Profile profile);
    Profile? GetById(int id);
    List<Profile> GetByLocation(Location location);
    void Inactivate(Profile profile);
}
