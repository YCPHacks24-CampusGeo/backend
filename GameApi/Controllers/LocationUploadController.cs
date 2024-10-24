using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LocationUploadController : ControllerBase
{
    [HttpPost(Name = "UploadLocation")]
    public void UploadLocation(GeoLocation geoLocation, LocationTag[] locationTags, string locationName)
    {

    }
}
