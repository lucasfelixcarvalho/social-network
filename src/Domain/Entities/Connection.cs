namespace Domain.Entities;

public class Connection
{
    public Connection(int profileIdFollower, int profileIdFollowing, DateTime connectionDate)
    {
        ProfileIdFollower = profileIdFollower;
        ProfileIdFollowing = profileIdFollowing;
        ConnectionDate = connectionDate;
    }

    protected Connection() { } // For EF

    public int ProfileIdFollower { get; private set; }
    public Profile ProfileFollower { get; private set; }

    public int ProfileIdFollowing { get; private set; }
    public Profile ProfileFollowing { get; private set; }

    public DateTime ConnectionDate { get; private set; }
}
