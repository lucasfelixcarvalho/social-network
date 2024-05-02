namespace Domain.ValueObjects;

public record Location(string City, string Country)
{
    public string GetFullLocation() => $"{City} - {Country}";
}
