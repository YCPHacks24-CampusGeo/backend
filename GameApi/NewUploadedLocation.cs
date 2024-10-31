namespace GameApi;

public class NewUploadedLocation
{
    public string Name { get; set; }
    public GeoLocation Location { get; set; }
    public LocationTag[] locationTags { get; set; }
}
