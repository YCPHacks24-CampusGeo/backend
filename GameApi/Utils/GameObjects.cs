using GameApi.Objects;
using System.Collections.Concurrent;

namespace GameApi.Utils;

public static class GameObjects
{
    public static List<Location> Locations = [
        new Location(new GeoLocation(39.946684456618776, -76.72852635383607), "00xldxp3.51k"),
        new Location(new GeoLocation(39.94652817803984, -76.72859743237495), "02w3vdgv.jl1"),
        new Location(new GeoLocation(39.94663716182333, -76.72863364219667), "5i0yjfgo.jt4"),
        new Location(new GeoLocation(39.94739079021644, -76.728785187006), "af0qnhyu.acg"),
        new Location(new GeoLocation(39.94596063704031, -76.73056617379189), "bqomedgt.llb"),
        new Location(new GeoLocation(39.94650658689232, -76.72807171940805), "fn5tw1qh.ly3"),
        new Location(new GeoLocation(39.94661351441337, -76.72860682010652), "k5liebc3.tyz"),
        new Location(new GeoLocation(39.945891750402915, -76.73060774803163), "njj4ueaj.34w"),
        new Location(new GeoLocation(39.94669679438612, -76.72796308994295), "obwynete.o4t"),
        new Location(new GeoLocation(39.94671735732675, -76.72790944576265), "qes2bxqk.fpj"),
        new Location(new GeoLocation(39.947324218329115, -76.73041865229607), "qxa3zrrx.rvw"),
        new Location(new GeoLocation(39.9466196833037, -76.72860145568848), "rfwrvs0a.kgr"),
        new Location(new GeoLocation(39.94734041149683, -76.72870740294458), "smau41rm.z03"),
        new Location(new GeoLocation(39.946725582501244, -76.72823667526245), "syxrxgom.bdm"),
        new Location(new GeoLocation(39.94659295144153, -76.7296126484871), "xjiggxt2.lyc"),
        new Location(new GeoLocation(39.948811660456926, -76.72672122716905), "xvfpozuq.kjh"),
        new Location(new GeoLocation(39.94596166519855, -76.73073112964632), "y2jop21x.iij"),
        new Location(new GeoLocation(39.945885581446916, -76.7304937541485), "zb5rn2pg.xwe"),
        new Location(new GeoLocation(39.94644386971083, -76.72855049371721), "zv4w1ozi.fch"),
    ];

    public static List<string> Markers = [
        "Burns",
    ];

    private static Random Random = new Random();

    private static ConcurrentQueue<T> CreateRandomQueue<T>(List<T> list)
    {
        T[] array = [.. list];
        Random.Shuffle(array);
        return new ConcurrentQueue<T>(array);
    }

    public static ConcurrentQueue<Location> CreateLocationQueue()
    {
        return CreateRandomQueue(Locations);
    }

    public static ConcurrentQueue<string> CreateMarkerQueue()
    {
        return CreateRandomQueue(Markers);
    }
}
