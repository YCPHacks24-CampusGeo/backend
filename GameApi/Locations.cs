namespace GameApi;

public static class Locations
{
    public static List<Location> List = [
        new Location(new GeoLocation(39.947324218329115, -76.73041865229607), "qxa3zrrx.rvw"),
    ];
}

public class Location
{
    public GeoLocation GeoLocation { get; set; }
    public string ImageKey;

    public Location(GeoLocation location, string imagekey)
    {
        GeoLocation = location;
        ImageKey = imagekey;
    }
}
