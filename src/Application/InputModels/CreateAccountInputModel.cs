namespace Application.InputModels;

public record CreateAccountInputModel(string fullname, string password, string email, DateOnly birth_date, string phone_number, string role);