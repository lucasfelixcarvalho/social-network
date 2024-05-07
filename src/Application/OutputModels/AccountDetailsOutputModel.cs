using Domain.Entities;

namespace Application.OutputModels;

public record AccountDetailsOutputModel(int id, string name, int profile_id)
{
    public static AccountDetailsOutputModel FromEntity(Account account)
    {
        return new AccountDetailsOutputModel(account.Id, account.FullName, account.ProfileId);
    }
}
