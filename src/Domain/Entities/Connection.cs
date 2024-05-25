namespace Domain.Entities;

public class Connection
{
    public Connection(int profileId, int profileIdFollowing, DateTime connectionDate)
    {
        ProfileId = profileId;
        ProfileIdFollowing = profileIdFollowing;
        ConnectionDate = connectionDate;
    }

    protected Connection() { } // For EF

    public int ProfileId { get; private set; }
    public Profile Profile { get; private set; }

    public int ProfileIdFollowing { get; private set; }
    public Profile ProfileFollowing { get; private set; }

    public DateTime ConnectionDate { get; private set; }
}
