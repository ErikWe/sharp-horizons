namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

public class Create_IEnumerable
{
    [Fact]
    public void Null_ArgumentNullException()
    {
        var factory = GetInstance();

        var collection = GetNullCollection();

        var exception = Record.Exception(() => factory.Create(collection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var factory = GetInstance();

        var collection = GetValidCollection();

        var actual = factory.Create(collection);

        Assert.Equal(collection.Count(), actual.Count());

        Assert.Equal(EpochSelectionMode.Collection, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static EpochCollectionFactory GetInstance() => new();

    private static IEnumerable<IEpoch> GetNullCollection() => null!;
    private static IEnumerable<IEpoch> GetValidCollection() => new[] { JulianDay.Epoch };
}
