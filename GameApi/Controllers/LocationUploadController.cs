using GameApi.Objects;
using GameApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class LocatioTestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLocation()
    {
        Random r = new Random();
        int i = r.Next(GameObjects.Locations.Count);
        return Ok(GameObjects.Locations[i]);
    }
}
