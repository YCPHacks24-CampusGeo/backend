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
    [HttpGet]
    public IActionResult GetLocation()
    {
        Random r = new Random();
        int i = r.Next(GameObjects.Locations.Count);
        return Ok(GameObjects.Locations[i]);
    }

    [HttpGet]
    public IActionResult GetIcon()
    {
        Random r = new Random();
        int i = r.Next(GameObjects.Markers.Count);

        return Ok(new
        {
            Icon = GameObjects.Markers[i],
            Name = Generators.GenerateName(),
        });
    }

}
