namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using System;

using Xunit;

public class IEpoch_FromJulianDay
{
    private static Epoch Target(JulianDay julianDay)
    {
        return execute<Epoch>();

        Epoch execute<T>() where T : IEpoch<Epoch> => T.FromJulianDay(julianDay);
    }

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
    [ClassData(typeof(Datasets.ConvertibleJulianDay))]
    public void Convertible_ExactMatchEpochFromJulianDay(JulianDay julianDay)
    {
        var expected = Epoch.FromJulianDay(julianDay);

        var actual = Target(julianDay);

        Assert.Equal(expected, actual);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<TException>(exception);
    }
}
