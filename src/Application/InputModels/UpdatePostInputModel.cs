namespace Application.InputModels;

public record UpdatePostInputModel(string content, DateTime publish_date, string city, string country);