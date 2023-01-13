namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Linq;

using Xunit;

internal static class Executor_Create_Params
{
    public static void Null_ArgumentNullException(IEpochCollectionFactory factory) => Null_ArgumentNullException(factory.Create);
    public static void Null_ArgumentNullException(Func<IEpoch[], IEpochCollection> factory)
    {
        var collection = GetNullCollection();

        var exception = Record.Exception(() => factory(collection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_ExactMatch(IEpochCollectionFactory factory) => Valid_ExactMatch(factory.Create);
    public static void Valid_ExactMatch(Func<IEpoch[], IEpochCollection> factory)
    {
        var collection = GetValidCollection();

        var actual = factory(collection);

        Assert.Equal(collection.Length, actual.Count());

        Assert.Equal(EpochSelectionMode.Collection, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IEpoch[] GetNullCollection() => null!;
    private static IEpoch[] GetValidCollection() => new[] { JulianDay.Epoch };
}
