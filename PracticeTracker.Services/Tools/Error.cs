namespace PracticeTracker.Services.Tools;

public class Error
{
    public String Message { get; }
    public String Key { get; }

    public Error(String message)
    {
        Message = message;
    }

    public Error(String key, String message)
    {
        Key = key;
        Message = message;
    }
}