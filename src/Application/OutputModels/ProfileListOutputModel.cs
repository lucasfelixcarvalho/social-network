using Domain.Entities;

namespace Application.OutputModels;

public record ProfileListOutputModel(int id, string display_name, string photo)
{
    public static ProfileListOutputModel FromEntity(Profile profile)
    {
        return new ProfileListOutputModel(profile.Id, profile.DisplayName, profile.Photo);
    }
}
