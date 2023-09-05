using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using TwilioApp.Configurations;

namespace TwilioApp.Services;

public class TwilioService : ITwilioService
{
    private readonly TwilioConfig _twilioConfig;
    public TwilioService(IOptionsMonitor<TwilioConfig> optionsMonitor)
    {
        _twilioConfig = optionsMonitor.CurrentValue;
    }


    public void SendMessage(string sender, string message)
    {
        TwilioClient.Init(_twilioConfig.AccountSid, _twilioConfig.AuthToken);
        var messageOptions = new CreateMessageOptions(new PhoneNumber(sender))
        {
            From = new PhoneNumber(_twilioConfig.TwilioPhoneNumber),
            Body = $"{message}"
        };

        MessageResource.Create(messageOptions);
    }
}