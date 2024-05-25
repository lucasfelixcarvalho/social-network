using Application.InputModels;
using Application.OutputModels;

namespace Application.Services;

public interface IPostService
{
    ResultOutputModel<int> Insert(CreatePostInputModel model);
    ResultOutputModel Delete(int id);
    ResultOutputModel Update(int id, UpdatePostInputModel model);
    ResultOutputModel<List<PostListOutputModel>> GetByProfileId(int profileId);
    ResultOutputModel<PostDetailsOutputModel> GetByid(int id);
}
