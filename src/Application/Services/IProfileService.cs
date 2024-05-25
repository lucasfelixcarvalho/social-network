using Application.InputModels;
using Application.OutputModels;

namespace Application.Services;

public interface IProfileService
{
    ResultOutputModel Update(int id, UpdateProfileInputModel model);
    ResultOutputModel<ProfileDetailsOutputModel?> GetProfileById(int id);
    ResultOutputModel<List<ProfileListOutputModel>> GetProfilesByLocation(LocationInputModel model);
    ResultOutputModel Inactivate(int id);
    void Create(CreateProfileInputModel model);
}
