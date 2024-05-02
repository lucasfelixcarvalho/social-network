using Domain.Entities;

namespace Domain.Repositories;

public interface IAccountRepository
{
    int Insert(Account account);
    void Update();
    Account? GetByLoginAndHash(string email, string hash);
}
