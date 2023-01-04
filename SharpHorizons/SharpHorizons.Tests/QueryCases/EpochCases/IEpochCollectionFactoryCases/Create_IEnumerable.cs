namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

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
        var factory = GetService();

        var collection = GetInvalidCollection();

        var exception = Record.Exception(() => factory.Create(collection));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var factory = GetService();

        var collection = GetValidCollection();

        var actual = factory.Create(collection);

        Assert.Equal(collection.Count(), actual.Count());

        Assert.Equal(EpochSelectionMode.Collection, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IEpochCollectionFactory GetService() => DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

    private static IEnumerable<IEpoch> GetInvalidCollection() => null!;
    private static IEnumerable<IEpoch> GetValidCollection() => new[] { JulianDay.Epoch };
}
