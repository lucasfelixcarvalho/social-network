namespace Application.InputModels;

public record CreateProfileInputModel(int account_id, string display_name, string bio, string photo, string city, string country, string? profession)
{
    public static CreateProfileInputModel EmptyProfile(int accountId, string displayName)
    {
        return new CreateProfileInputModel(accountId, displayName, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
