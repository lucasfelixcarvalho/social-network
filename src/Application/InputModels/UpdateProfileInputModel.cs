namespace Application.InputModels;

public record UpdateProfileInputModel(string display_name, LocationInputModel location, string bio, string photo, string? profession);
