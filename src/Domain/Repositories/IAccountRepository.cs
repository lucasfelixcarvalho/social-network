using Domain.Entities;

namespace Domain.Repositories;

public interface IAccountRepository
{
    void Insert(Account account);
    void Update(Account account);
    Account? GetByLoginAndHash(string email, string hash);
    Account? GetById(int id);
}
