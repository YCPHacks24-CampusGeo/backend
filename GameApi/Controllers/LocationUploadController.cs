using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class LocationUploadController : ControllerBase
{
    [DisableRequestSizeLimit]
    [HttpPost(Name = "UploadLocation")]
    public void UploadLocation(NewUploadedLocation uploadedLocation)
    {
        Console.WriteLine(uploadedLocation.Location.Latitude);
        Console.WriteLine(uploadedLocation.Location.Longitude);
        Console.WriteLine(uploadedLocation.base64JPG[0..100]);
    }
}
