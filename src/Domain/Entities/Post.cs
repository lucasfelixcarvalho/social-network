using Domain.ValueObjects;

namespace Domain.Entities;

public class Post : BaseEntity
{
    public Post(string content, DateTime publishedAt, Location location, int profileId) : base()
    {
        Content = content;
        PublishedAt = publishedAt;
        Location = location;
        ProfileId = profileId;
    }

    protected Post() { } // For EF

    public string Content { get; private set; }
    public DateTime PublishedAt { get; private set; }
    public Location Location { get; set; }
    public int ProfileId { get; private set; }
    public Profile Profile { get; private set; }

    public void Update(string content, DateTime publishDate, Location location)
    {
        Content = content;
        PublishedAt = publishDate;
        Location = location;
    }
}
