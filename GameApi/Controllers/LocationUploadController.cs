using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

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

        string jsonString = JsonSerializer.Serialize(uploadedLocation);

        string path = $"/uploaded_locations/{Path.GetRandomFileName()}.json";

        using FileStream fs = System.IO.File.Create(path);
        System.IO.File.WriteAllText(path, jsonString);
    }
}
