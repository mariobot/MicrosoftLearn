using Microsoft.AspNetCore.Mvc;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController(ChatServices chatServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Chat([FromBody] Chat chat)
    {
        var result = chatServices.Send(chat.Prompt);
        return Ok(result);
    }
}

public record Chat(string Prompt);
