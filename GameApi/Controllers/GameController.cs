using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class GameController : AbstractGameController
{
    [HttpGet]
    public IActionResult GetScores()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetGameState()
    {
        throw new NotImplementedException();
    }
}
