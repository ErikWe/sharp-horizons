namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class ToJulianDay
{
    private static JulianDay Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.ToJulianDay();

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Unconvertible_EpochOutOfBoundsException(ModifiedJulianDay modifiedJulianDay)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay));

        Assert.IsType<EpochOutOfBoundsException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ModifiedJulianDayAndEquivalentJulianDay))]
    public void Convertible_ApproximateMatch(ModifiedJulianDay modifiedJulianDay, JulianDay julianDay)
    {
        var actual = Target(modifiedJulianDay);

        Asserter.Approximate(julianDay.Day, actual.Day);
    }
}
