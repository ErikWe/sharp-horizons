namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

internal static class Executor_Create_IEnumerable
{
    public static void Null_ArgumentNullException(IEpochCollectionFactory factory) => Null_ArgumentNullException(factory.Create);
    public static void Null_ArgumentNullException(Func<IEnumerable<IEpoch>, IEpochCollection> factory)
    {
        var collection = GetNullCollection();

        var exception = Record.Exception(() => factory(collection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    public static void Valid_ExactMatch(IEpochCollectionFactory factory) => Valid_ExactMatch(factory.Create);
    public static void Valid_ExactMatch(Func<IEnumerable<IEpoch>, IEpochCollection> factory)
    {
        var collection = GetValidCollection();

        var actual = factory(collection);

        Assert.Equal(collection.Count(), actual.Count());

        Assert.Equal(EpochSelectionMode.Collection, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IEnumerable<IEpoch> GetNullCollection() => null!;
    private static IEnumerable<IEpoch> GetValidCollection() => new[] { JulianDay.Epoch };
}
