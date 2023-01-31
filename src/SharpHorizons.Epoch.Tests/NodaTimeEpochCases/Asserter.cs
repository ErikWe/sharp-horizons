namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

internal static class Asserter
{
    public static void ApproximateJulianDay(JulianDay expected, JulianDay actual) => JulianDayCases.Asserter.Approximate(expected.Day, actual.Day);
    public static void Approximate(Epoch expected, Epoch actual) => ApproximateJulianDay(new JulianDay(expected.Instant.ToJulianDate()), new JulianDay(actual.Instant.ToJulianDate()));
}
