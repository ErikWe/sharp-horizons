namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using System.ComponentModel;

using Xunit;

public class WithConfiguration_TimeDeltaInclusion
{
    [Fact]
    public void Invalid_InvalidEnumArgumentException()
    {
        var vectorsQuery = GetVectorsQuery();

        var timeDeltaInclusion = GetInvalidTimeDeltaInclusion();

        var exception = Record.Exception(() => vectorsQuery.WithConfiguration(timeDeltaInclusion));

        Assert.IsType<InvalidEnumArgumentException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.TimeDeltaInclusion;

        var timeDeltaInclusion = GetDifferentTimeDeltaInclusion(previous);

        var actual = vectorsQuery.WithConfiguration(timeDeltaInclusion);

        Assert.NotEqual(previous, timeDeltaInclusion);
        Assert.Equal(timeDeltaInclusion, actual.TimeDeltaInclusion);
    }

    [Fact]
    public void Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previous = vectorsQuery.TimeDeltaInclusion;

        var timeDeltaInclusion = GetDifferentTimeDeltaInclusion(previous);

        vectorsQuery.WithConfiguration(timeDeltaInclusion);

        Assert.NotEqual(previous, timeDeltaInclusion);
        Assert.Equal(previous, vectorsQuery.TimeDeltaInclusion);
    }

    private static IVectorsQuery GetVectorsQuery()
    {
        var factory = DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

        return factory.Create(GetValidTarget(), GetValidOrigin(), GetValidEpochSelection());
    }

    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }

    private static TimeDeltaInclusion GetInvalidTimeDeltaInclusion() => (TimeDeltaInclusion)(-1);
    private static TimeDeltaInclusion GetDifferentTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion) => timeDeltaInclusion switch
    {
        TimeDeltaInclusion.Enable => TimeDeltaInclusion.Disable,
        TimeDeltaInclusion.Disable => TimeDeltaInclusion.Enable,
        _ => throw new InvalidEnumArgumentException()
    };
}
