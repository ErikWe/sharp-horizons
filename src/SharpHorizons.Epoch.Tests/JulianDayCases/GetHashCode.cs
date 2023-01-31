namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using Xunit;

public class GetHashCode
{
    private static int Target(JulianDay julianDay) => julianDay.GetHashCode();

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_SameIfEqual(JulianDay julianDay)
    {
        JulianDay other = new(julianDay.Day);

        var expected = Target(other);

        var actual = Target(julianDay);

        Assert.Equal(expected, actual);
    }
}
