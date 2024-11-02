using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UserController : AbstractGameController
{
    [HttpPost]
    public IActionResult MakeGuess()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetGuessImage()
    {
        throw new NotImplementedException();
    }

    /*
    [HttpPost]
    public IActionResult ExitGame()
    {
        throw new NotImplementedException();
    }*/

    [HttpGet]
    public IActionResult GetPlayerIcon()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetPlayerScore()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult GetPlayerResults()
    {
        throw new NotImplementedException();
    }
}