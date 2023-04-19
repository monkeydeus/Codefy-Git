using Microsoft.AspNetCore.Mvc;

namespace Codefy_API.Controllers;

[ApiController]
[Route("[controller]")]
public class StateController : ControllerBase
{
    private static readonly string[] Mottos = new[]
    {
        "It's a dry heat", "It's a wet mess", "The bee's knees", "Rocky Mountain Hight", "Bring more money than that", "Almost Arizona"
    };

    private static readonly string[] States = new[]
    {
        "Arizona", "Oregon", "Utah", "Colorado", "Nevada", "New Mexico"
    };

    private readonly ILogger<StateController> _logger;

    public StateController(ILogger<StateController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetState")]
    public State Get()
    {
        var pos = Random.Shared.Next(States.Length);
        return new State
        {

            Name = States[pos],
            YearFounded = Random.Shared.Next(1776, 1912),
            Motto = Mottos[pos]
        };
    }
}
