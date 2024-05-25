using Domain.Entities;

namespace Application.OutputModels;

public record PostDetailsOutputModel(int id, string content, DateTime published_at, string location, int profile_id)
{
    public static PostDetailsOutputModel FromEntity(Post post)
    {
        return new PostDetailsOutputModel(post.Id, post.Content, post.PublishedAt, post.Location.GetFullLocation(), post.ProfileId);
    }
}
