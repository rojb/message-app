namespace TwilioApp.Services;

public interface IOpenAIService
{
    Task<string> CompleteSentence(string text);
    Task<string> ChatCompletion(string text);
}