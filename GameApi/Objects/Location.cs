namespace GameApi.Objects;

public class Location
{
    public GeoLocation GeoLocation { get; set; }
    public string ImageKey { get; set; }

    public Location(GeoLocation location, string imagekey)
    {
        GeoLocation = location;
        ImageKey = imagekey;
    }
}
