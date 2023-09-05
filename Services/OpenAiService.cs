using Microsoft.Extensions.Options;
using TwilioApp.Configurations;

namespace TwilioApp.Services;

public class OpenAiService : IOpenAIService
{
    private readonly OpenAiConfig _openIaConfig;
    public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor)
    {
        _openIaConfig = optionsMonitor.CurrentValue;
    }

    public async Task<string> CompleteSentence(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openIaConfig.Key);
        var result = await api.Completions.GetCompletion(text);
        return result;
    }
    public async Task<string> ChatCompletion(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openIaConfig.Key);
        var chat = api.Chat.CreateConversation();
        chat.AppendUserInput(text);
        var response = await chat.GetResponseFromChatbotAsync();
        return response;
    }
}