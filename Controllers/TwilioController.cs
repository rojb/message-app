using Microsoft.AspNetCore.Mvc;
using TwilioApp.Services;

namespace TwilioApp.Controllers;

[ApiController]
[Route("api/messages")]
public class TwilioController : ControllerBase
{
    private readonly IOpenAIService _openAiService;
    private readonly ITwilioService _twilioService;

    public TwilioController(IOpenAIService openAiService, ITwilioService twilioService)
    {
        _openAiService = openAiService;
        _twilioService = twilioService;
    }

    [HttpPost]
    public async Task<ActionResult> ManageMessage()
    {
        string? from = Request.Form["From"];
        string? body = Request.Form["Body"];
        
        if (from is null)
        {
            return BadRequest();
        }
        if (body is null)
        {
            return BadRequest();
        }
        var newMessage = await _openAiService.ChatCompletion(body);
        _twilioService.SendMessage(from, newMessage);
        return Ok();
    }
}
