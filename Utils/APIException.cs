namespace api_team.Utils;

public class APIException : Exception
{
    public string Title { get; set; } = "API Error";

    public int StatusCode { get; set; } = 400;

    public APIException(string message) : base(message)
    {}

    public APIException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

}