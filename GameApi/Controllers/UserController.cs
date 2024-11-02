using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UserController : AbstractGameController
{
    [HttpPost]
    public void MakeGuess()
    {

    }

    [HttpGet]
    public void GetGuessImage()
    {

    }

    [HttpPost]
    public void ExitGame()
    {

    }

    [HttpGet]
    public void GetPlayerIcon()
    {

    }

    [HttpGet]
    public void GetPlayerScore()
    {

    }

    [HttpGet]
    public void GetPlayerResults()
    {

    }
}