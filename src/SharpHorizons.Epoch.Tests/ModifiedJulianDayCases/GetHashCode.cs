namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using Xunit;

public class GetHashCode
{
    private static int Target(ModifiedJulianDay modifiedJulianDay) => modifiedJulianDay.GetHashCode();

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Valid_SameIfEqual(ModifiedJulianDay modifiedJulianDay)
    {
        ModifiedJulianDay other = new(modifiedJulianDay.Day);

        var expected = Target(other);

        var actual = Target(modifiedJulianDay);

        Assert.Equal(expected, actual);
    }
}
