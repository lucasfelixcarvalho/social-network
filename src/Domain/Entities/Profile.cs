using Domain.ValueObjects;

namespace Domain.Entities;

public class Profile : BaseEntity
{
    public Profile(string displayName, string bio, string photo, Location location, string? profession) : base()
    {
        DisplayName = displayName;
        Bio = bio;
        Photo = photo;
        Location = location;
        Profession = profession;
        Posts = [];
    }

    protected Profile() { } // For EF

    public string DisplayName { get; private set; }
    public string Bio { get; private set; }
    public string Photo { get; private set; }
    public Location Location { get; private set; }
    public string? Profession { get; private set; }
    public List<Post> Posts { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
}
