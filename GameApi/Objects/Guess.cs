namespace GameApi.Objects;

public class Guess
{
    public GeoLocation Location { get; set; }
    public double Distance { get; set; }
    public uint Points { get; set; }

    public Guess(GeoLocation guess, GeoLocation? correct)
    {
        Location = guess;
        if (correct == null)
        {
            Distance = double.MaxValue;
            Points = 0;
        } else
        {
            Distance = ScoreCalculator.CalculateDistance(guess, correct);
            double scaledDistance = ScoreCalculator.ScaleDistance(Distance);
            double rawPoints = ScoreCalculator.CalculatePoints(scaledDistance);
            Points = ScoreCalculator.ScalePoints(rawPoints);
        }
    }
}

/*
Calculate Distance
ScaleDistance
CalculatePoints
ScalePoints
*/
internal static class ScoreCalculator
{
    internal const double FULL_POINTS_THRESHOLD = 1d;
    internal const double NO_POINTS_THRESHOLD = 500d;

    internal const uint MAX_POINTS = 1_000;

    internal const double EARTH_RADIUS = 6371d;

    internal static double CalculateDistance(GeoLocation guess, GeoLocation correct)
    {
        // distance between latitudes and longitudes
        double dLat = (Math.PI / 180) * (correct.Latitude - guess.Latitude);
        double dLon = (Math.PI / 180) * (correct.Longitude - guess.Longitude);

        // convert to radians
        double rlat1 = (Math.PI / 180) * (guess.Latitude);
        double rlat2 = (Math.PI / 180) * (correct.Latitude);

        // apply formula
        double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                   Math.Pow(Math.Sin(dLon / 2), 2) *
                   Math.Cos(rlat1) * Math.Cos(rlat2);
        double c = 2 * Math.Asin(Math.Sqrt(a));
        return EARTH_RADIUS * c * 1_000;
    }

    // Output 0 - perfect
    // Output 1 - farthest
    internal static double ScaleDistance(double distance)
    {
        double result = (NO_POINTS_THRESHOLD - distance) / (NO_POINTS_THRESHOLD - FULL_POINTS_THRESHOLD);
        return Math.Clamp(result, 0d, 1d);
    }

    // Output 0 - no points
    // Output 1 - full points
    internal static double CalculatePoints(double scaledDistance)
    {
        double halfpi = Math.PI / 2d;

        double xpower = 13d / 20d;
        double xscale = 28_849d / 720d;

        double addend = 1d;
        double denominator = 2d;

        double result = (Math.Sin(Math.Pow(scaledDistance, xpower) * xscale + halfpi) + addend) / denominator;

        return Math.Clamp(result, 0d, 1d);
    }

    internal static uint ScalePoints(double points)
    {
        double scaled = points * MAX_POINTS;
        int intpts = (int) Math.Ceiling(scaled);
        return (uint)Math.Clamp(intpts, 0, MAX_POINTS);
    }
}