using Application.InputModels;
using Application.OutputModels;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class PostService(IPostRepository repository) : IPostService
{
    private readonly IPostRepository _repository = repository;

    public ResultOutputModel Delete(int id)
    {
        Post? post = _repository.GetById(id);

        if (post is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        _repository.Delete(post);
        return ResultOutputModel.Success();
    }

    public ResultOutputModel<PostDetailsOutputModel> GetByid(int id)
    {
        Post? post = _repository.GetById(id);

        if (post is null)
        {
            return ResultOutputModel<PostDetailsOutputModel>.Failure("Not Found");
        }

        return ResultOutputModel<PostDetailsOutputModel>.Success(PostDetailsOutputModel.FromEntity(post));
    }

    public ResultOutputModel<List<PostListOutputModel>> GetByProfileId(int profileId)
    {
        List<Post> posts = _repository.GetByProfileId(profileId);
        List<PostListOutputModel> models = posts.Select(PostListOutputModel.FromEntity).ToList();
        return ResultOutputModel<List<PostListOutputModel>>.Success(models);
    }

    public ResultOutputModel<int> Insert(CreatePostInputModel model)
    {
        Post post = new(model.content, model.publish_date, new Location(model.city, model.country), model.profileId);
        _repository.Insert(post);
        return ResultOutputModel<int>.Success(post.Id);
    }

    public ResultOutputModel Update(int id, UpdatePostInputModel model)
    {
        Post? post = _repository.GetById(id);

        if (post is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        post.Update(model.content, model.publish_date, new Location(model.city, model.country));
        _repository.Update(post);
        return ResultOutputModel.Success();
    }
}
