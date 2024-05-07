using Application.InputModels;
using Application.OutputModels;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class ProfileService(IProfileRepository repository) : IProfileService
{
    private readonly IProfileRepository _repository = repository;

    public void Create(CreateProfileInputModel model)
    {
        _repository.Create(new Profile(model.account_id, model.display_name, model.bio, model.photo, new Location(model.city, model.country), model.profession));
    }

    public ResultOutputModel<ProfileDetailsOutputModel?> GetProfileById(int id)
    {
        Profile? profile = _repository.GetById(id);

        if (profile is null)
        {
            return ResultOutputModel<ProfileDetailsOutputModel?>.Failure("Not Found");
        }

        return ResultOutputModel<ProfileDetailsOutputModel?>.Success(ProfileDetailsOutputModel.FromEntity(profile));
    }

    public ResultOutputModel<List<ProfileListOutputModel>> GetProfilesByLocation(LocationInputModel model)
    {
        List<Profile> profiles = _repository.GetByLocation(new Location(model.city, model.country));
        List<ProfileListOutputModel> result = profiles.Select(ProfileListOutputModel.FromEntity).ToList();
        return ResultOutputModel<List<ProfileListOutputModel>>.Success(result);
    }

    public ResultOutputModel Inactivate(int id)
    {
        Profile? profile = _repository.GetById(id);

        if (profile is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        profile.Inactivate();
        _repository.Update(profile);
        return ResultOutputModel.Success();
    }

    public ResultOutputModel Update(int id, UpdateProfileInputModel model)
    {
        Profile? profile = _repository.GetById(id);

        if (profile is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        profile.Update(model.display_name, new Location(model.location.city, model.location.country), model.bio, model.photo, model.profession);
        _repository.Update(profile);
        return ResultOutputModel.Success();
    }
}
