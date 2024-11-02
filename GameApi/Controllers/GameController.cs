using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class GameController : AbstractGameController
{
    [HttpGet]
    public void GetScores()
    {

    }

    [HttpGet]
    public void GetGameState()
    {

    }
}
