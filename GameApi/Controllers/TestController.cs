using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Text.Json;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    private Random r = new Random();

    [NonAction]
    public Location GetRandomLocation()
    {
        int i = r.Next(GameObjects.Locations.Count);
        return GameObjects.Locations[i];
    }

    [HttpGet]
    public IActionResult GetLocation()
    {
        return Ok(GetRandomLocation());
    }

    [HttpGet]
    public IActionResult GetIcon()
    {
        int i = r.Next(GameObjects.Markers.Count);

        return Ok(new
        {
            Icon = GameObjects.Markers[i],
            Name = Generators.GenerateName(),
        });
    }

    [HttpGet]
    public IActionResult GetResults()
    {
        var correct = GetRandomLocation().GeoLocation;

        return Ok(new
        {
            Correct = correct,
            Guess = new Guess(GetRandomLocation().GeoLocation, correct),
        });
    }

}
