namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class FromJulianDay
{
    private static Epoch Target(JulianDay julianDay) => Epoch.FromJulianDay(julianDay);

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
    [ClassData(typeof(Datasets.EpochAndEquivalentJulianDay))]
    public void Convertible_ApproximateMatch(Epoch epoch, JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Asserter.Approximate(epoch, actual);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<TException>(exception);
    }
}
