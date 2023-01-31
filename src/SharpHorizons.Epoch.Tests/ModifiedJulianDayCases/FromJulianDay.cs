namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class FromJulianDay
{
    private static ModifiedJulianDay Target(JulianDay julianDay) => ModifiedJulianDay.FromJulianDay(julianDay);

    [Fact]
    public void Null_ArgumentNullException()
    {
        var julianDay = Datasets.GetNullJulianDay();

        AnyError_TException<ArgumentNullException>(julianDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleJulianDay))]
    public void Unconvertible_ArgumentOutOfRangeException(JulianDay julianDay) => AnyError_TException<ArgumentOutOfRangeException>(julianDay);

    [Theory]
    [ClassData(typeof(Datasets.ModifiedJulianDayAndEquivalentJulianDay))]
    public void Valid_ApproximateMatch(ModifiedJulianDay modifiedJulianDay, JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Asserter.Approximate(modifiedJulianDay.Day, actual.Day);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<TException>(exception);
    }
}
