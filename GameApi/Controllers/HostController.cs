using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class HostController : AbstractGameController
{
    [HttpGet]
    public void GetGuesses()
    {
        
    }

    [HttpPost]
    public void CreateGame()
    {

    }

    [HttpGet]
    public void GetGameSettings()
    {

    }

    [HttpPost]
    public void StartGame()
    {

    }

    /*
    [HttpPost]
    public void DeleteGame()
    {

    }
    */
}
