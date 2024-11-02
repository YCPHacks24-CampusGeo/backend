using Microsoft.AspNetCore.Mvc;
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

        Console.WriteLine($"Creating file at: {path}");

        System.IO.File.WriteAllText(path, jsonString);
        Console.WriteLine("File created and written successfully");
    }
}
