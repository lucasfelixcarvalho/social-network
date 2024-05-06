using Domain.Entities;

namespace Application.InputModels;

public record PostListOutputModel(int id, int profile_id, string first_100_characters, string location)
{
    public static PostListOutputModel FromEntity(Post post)
    {
        string content = post.Content.Length > 100 ? post.Content[..100] : post.Content;
        return new PostListOutputModel(post.Id, post.ProfileId, content, post.Location.GetFullLocation());
    }
}
