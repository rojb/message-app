namespace TwilioApp.Services;

public interface ITwilioService
{
    void SendMessage(string sender, string message);
}