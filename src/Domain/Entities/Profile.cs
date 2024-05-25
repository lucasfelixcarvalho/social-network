using Domain.ValueObjects;

namespace Domain.Entities;

public class Profile : BaseEntity
{
    public Profile(int accountId, string displayName, string bio, string photo, Location location, string? profession) : base()
    {
        AccountId = accountId;
        DisplayName = displayName;
        Bio = bio;
        Photo = photo;
        Location = location;
        Active = true;
        Profession = profession;
        Posts = [];
        Followers = [];
        Following = [];
    }

    protected Profile() { } // For EF

    public string DisplayName { get; private set; }
    public string Bio { get; private set; }
    public string Photo { get; private set; }
    public Location Location { get; private set; }
    public bool Active { get; private set; }
    public string? Profession { get; private set; }
    public List<Post> Posts { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
    public List<Connection> Followers { get; private set; }
    public List<Connection> Following { get; private set; }

    public void Update(string newDisplayName, Location location, string newBio, string newPhoto, string? newProfession)
    {
        DisplayName = newDisplayName;
        Location = location;
        Bio = newBio;
        Photo = newPhoto;
        Profession = newProfession;
    }

    public void Inactivate()
    {
        Active = false;
    }
}
