using System.Text;
using ChatApplication.BotDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoBot;

namespace OtoBotAPI.Controllers;

/// <summary>
/// Point of bot answer for you request.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BotController : ControllerBase
{

    private readonly ILogger<BotController> _logger;

    public BotController(ILogger<BotController> logger)
    {
            _logger = logger;
    }

    /// <summary>
    /// sends answer.
    /// </summary>
    /// <returns>String answer.</returns>
    [Authorize]
    [HttpGet(Name = "GetBot")]
    public async Task<IActionResult> Get([FromBody] BotTransferMessageModel messageModel)
    {
        var botAnswer = await Message.GetBotAnswer(messageModel.Message);
        return Ok(botAnswer);
    }
        
    
}