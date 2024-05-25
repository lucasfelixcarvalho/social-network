namespace Application.InputModels;

public record CreateAccountInputModel(string fullname, string password, string email, DateTime birth_date, string phone_number, string role);