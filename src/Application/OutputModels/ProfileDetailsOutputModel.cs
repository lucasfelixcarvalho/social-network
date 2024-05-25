using Domain.Entities;

namespace Application.OutputModels;

public record ProfileDetailsOutputModel(int id, string display_name, string bio, string photo, string? profession)
{
    public static ProfileDetailsOutputModel FromEntity(Profile profile)
    {
        return new ProfileDetailsOutputModel(profile.Id, profile.DisplayName, profile.Bio, profile.Photo, profile.Profession);
    }
}
