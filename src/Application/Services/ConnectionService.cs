using Application.InputModels;
using Application.OutputModels;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class ConnectionService(IConnectionRepository repository) : IConnectionService
{
    private readonly IConnectionRepository _repository = repository;

    public ResultOutputModel Follow(FollowProfileInputModel model)
    {
        Connection connection = new(model.profile_id, model.profile_id_to_follow, DateTime.Now);
        _repository.Follow(connection);
        return ResultOutputModel.Success();
    }

    public ResultOutputModel Unfollow(UnfollowProfileInputModel model)
    {
        Connection connection = new(model.profile_id, model.profile_id_to_unfollow, DateTime.Now);
        _repository.Unfollow(connection);
        return ResultOutputModel.Success();
    }
}
