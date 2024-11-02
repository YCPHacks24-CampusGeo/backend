namespace GameApi.Objects;

public class Guess
{
    public GeoLocation Location { get; set; }
    public double Distance { get; set; }
    public uint Points { get; set; }
}
