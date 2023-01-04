namespace SharpHorizons.Tests.QueryCases.EpochCases.ITimeSystemOffsetProviderCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

using Xunit;

public class Offset
{
    [Fact]
    public void NullEpoch_ArgumentNullException()
    {
        var epoch = GetInvalidEpoch();
        var origin = GetValidTimeSystem();
        var target = GetValidTimeSystem();

        AnyError_TException<ArgumentNullException>(epoch, origin, target);
    }

    [Fact]
    public void InvalidOrigin_InvalidEnumArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetInvalidTimeSystem();
        var target = GetValidTimeSystem();

        AnyError_TException<InvalidEnumArgumentException>(epoch, origin, target);
    }

    [Fact]
    public void ForbiddenOrigin_ArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetForbiddenTimeSystem();
        var target = GetValidTimeSystem();

        AnyError_TException<ArgumentException>(epoch, origin, target);
    }

    [Fact]
    public void InvalidTarget_InvalidEnumArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetValidTimeSystem();
        var target = GetInvalidTimeSystem();

        AnyError_TException<InvalidEnumArgumentException>(epoch, origin, target);
    }

    [Fact]
    public void ForbiddenTarget_ArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetValidTimeSystem();
        var target = GetForbiddenTimeSystem();

        AnyError_TException<ArgumentException>(epoch, origin, target);
    }

    [Fact]
    public void NullEpochAndInvalidOriginAndTarget_ArgumentNullException()
    {
        var epoch = GetInvalidEpoch();
        var origin = GetInvalidTimeSystem();
        var target = GetInvalidTimeSystem();

        AnyError_TException<ArgumentNullException>(epoch, origin, target);
    }

    [Fact]
    public void InvalidOriginAndForbiddenTarget_InvalidEnumArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetInvalidTimeSystem();
        var target = GetForbiddenTimeSystem();

        AnyError_TException<InvalidEnumArgumentException>(epoch, origin, target);
    }

    [Fact]
    public void ForbiddenOriginAndInvalidTarget_InvalidEnumArgumentException()
    {
        var epoch = GetValidEpoch();
        var origin = GetForbiddenTimeSystem();
        var target = GetInvalidTimeSystem();

        AnyError_TException<InvalidEnumArgumentException>(epoch, origin, target);
    }

    private static void AnyError_TException<TException>(IEpoch epoch, TimeSystem origin, TimeSystem target) where TException : Exception
    {
        var provider = GetService();

        var exception = Record.Exception(() => provider.Offset(epoch, origin, target));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_Welldefined()
    {
        var provider = GetService();

        var epoch = GetValidEpoch();
        var origin = GetValidTimeSystem();
        var target = GetValidTimeSystem();

        var actual = provider.Offset(epoch, origin, target);

        Assert.True(actual.IsFinite);
    }

    [Fact]
    public void OriginSameAsTarget_Zero()
    {
        var provider = GetService();

        var epoch = GetValidEpoch();
        var origin = GetValidTimeSystem();
        var target = origin;

        var actual = provider.Offset(epoch, origin, target);

        Assert.Equal(Time.Zero, actual);
    }

    private static ITimeSystemOffsetProvider GetService() => DependencyInjection.GetRequiredService<ITimeSystemOffsetProvider>();

    private static IEpoch GetInvalidEpoch() => null!;
    private static IEpoch GetValidEpoch() => JulianDay.Epoch;

    private static TimeSystem GetInvalidTimeSystem() => (TimeSystem)4;
    private static TimeSystem GetForbiddenTimeSystem() => TimeSystem.Unknown;
    private static TimeSystem GetValidTimeSystem() => TimeSystem.UT;
}
