using Application.InputModels;
using Application.OutputModels;

namespace Application.Services;

public interface IConnectionService
{
    ResultOutputModel Follow(FollowProfileInputModel model);
    ResultOutputModel Unfollow(UnfollowProfileInputModel model);
}
