using Microsoft.AspNetCore.Mvc;

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
    [HttpGet(Name = "GetBot")]
    public string Get()
    {
        return "Hello from bot.";
    }
        
    
}