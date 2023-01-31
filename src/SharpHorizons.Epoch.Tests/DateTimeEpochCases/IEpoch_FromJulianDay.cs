namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class IEpoch_FromJulianDay
{
    private static DateTimeEpoch Target(JulianDay julianDay)
    {
        return execute<DateTimeEpoch>();

        DateTimeEpoch execute<T>() where T : IEpoch<DateTimeEpoch> => T.FromJulianDay(julianDay);
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
    public void Convertible_ExactMatchDateTimeEpochFromJulianDay(JulianDay julianDay)
    {
        var expected = DateTimeEpoch.FromJulianDay(julianDay);

        var actual = Target(julianDay);

        Assert.Equal(expected, actual);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<TException>(exception);
    }
}
