using Domain.Entities;

namespace Application.OutputModels;

public record AccountDetailsOutputModel(int id, string name)
{
    public static AccountDetailsOutputModel FromEntity(Account account)
    {
        return new AccountDetailsOutputModel(account.Id, account.FullName);
    }
}
