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

    [NonAction]
    public string GetRandomIcon()
    {
        int i = r.Next(GameObjects.Markers.Count);
        return GameObjects.Markers[i];
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

    [HttpGet]
    public IActionResult GetScores()
    {
        List<object> scores = [];

        int m = r.Next(2, 16);

        for (int i = 0; i < m; i++)
        {
            scores.Add(new
            {
                Name = Generators.GenerateName(),
                Icon = GetRandomIcon(),
                Score = r.Next(0, 15000),
            });
        }

        return Ok(scores);
    }

    [HttpGet]
    public IActionResult GetGuesses()
    {
        int m = r.Next(2, 16);
        List<object> guesses = [];

        for (int i = 0; i < m; i ++)
        {
            guesses.Add(new
            {
                Name = Generators.GenerateName(),
                Icon = GetRandomIcon(),
                Guess = GetRandomLocation().GeoLocation
            });
        }

        return Ok(new
        {
            Correct = GetRandomLocation(),
            Guesses = guesses
        });
    }
}
