namespace Application.InputModels;

public record CreatePostInputModel(string content, DateTime publish_date, string city, string country, int profileId);
