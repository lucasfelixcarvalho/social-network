namespace Domain.Entities;

public class Account : BaseEntity
{
    public Account(string fullName, string password, string email, DateOnly birthDate, string phoneNumber) : base()
    {
        FullName = fullName;
        Password = password;
        Email = email;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }

    protected Account() { } // For EF

    public string FullName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string PhoneNumber { get; set; }
    public int ProfileId { get; private set; }
    public Profile Profile { get; private set; }

    public void Update(string newFullName, string newPhoneNumber)
    {
        FullName = newFullName;
        Password = newPhoneNumber;
    }

    public void UpdatePassword(string newPassword)
    {
        Password = newPassword;
    }
}
