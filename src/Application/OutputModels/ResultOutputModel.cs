namespace Application.OutputModels;

public class ResultOutputModel(bool isSuccess = true, string message = "")
{
    public bool IsSuccess { get; set; } = isSuccess;
    public string Message { get; set; } = message;

    public static ResultOutputModel Success() => new();
    public static ResultOutputModel Failure(string message) => new(false, message);
}

public class ResultOutputModel<T>(T? data, bool isSuccess = true, string message = "") : ResultOutputModel(isSuccess, message)
{
    public T? Data { get; set; } = data;
    public static ResultOutputModel<T> Success(T data) => new(data);
    public static new ResultOutputModel<T> Failure(string message) => new(default, false, message);
}
