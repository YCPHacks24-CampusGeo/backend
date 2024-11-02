namespace GameApi.Objects;

public class GeoLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public GeoLocation() { }

    public GeoLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
