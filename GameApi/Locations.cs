namespace GameApi;

public static class GameObjects
{
    public static List<Location> Locations = [
        new Location(new GeoLocation(39.946684456618776, -76.72852635383607), "00xldxp3.51k"),
        new Location(new GeoLocation(39.94663716182333, -76.72863364219667), "5i0yjfgo.jt4"),
        new Location(new GeoLocation(39.94739079021644, -76.728785187006), "af0qnhyu.acg"),
        new Location(new GeoLocation(39.94650658689232, -76.72807171940805), "fn5tw1qh.ly3"),
        new Location(new GeoLocation(39.94661351441337, -76.72860682010652), "k5liebc3.tyz"),
        new Location(new GeoLocation(39.94669679438612, -76.72796308994295), "obwynete.o4t"),
        new Location(new GeoLocation(39.947324218329115, -76.73041865229607), "qxa3zrrx.rvw"),
        new Location(new GeoLocation(39.94734041149683, -76.72870740294458), "smau41rm.z03"),
        new Location(new GeoLocation(39.946725582501244, -76.72823667526245), "syxrxgom.bdm"),
        new Location(new GeoLocation(39.94659295144153, -76.7296126484871), "xjiggxt2.lyc"),
        new Location(new GeoLocation(39.948811660456926, -76.72672122716905), "xvfpozuq.kjh"),
        new Location(new GeoLocation(39.94644386971083, -76.72855049371721), "zv4w1ozi.fch"),
    ];

    public static List<string> Markers = [
        "Burns",
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
