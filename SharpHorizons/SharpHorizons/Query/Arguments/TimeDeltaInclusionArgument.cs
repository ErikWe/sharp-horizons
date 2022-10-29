namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="ITimeDeltaInclusionArgument"/>
internal sealed record class TimeDeltaInclusionArgument : ITimeDeltaInclusionArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="TimeDeltaInclusionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private TimeDeltaInclusionArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="ITimeDeltaInclusionArgument"/> describing <paramref name="timeDeltaInclusion"/>.</summary>
    /// <param name="timeDeltaInclusion">A <see cref="ITimeDeltaInclusionArgument"/> is composed based on this <see cref="TimeDeltaInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static ITimeDeltaInclusionArgument Extract(TimeDeltaInclusion timeDeltaInclusion) => new TimeDeltaInclusionArgument(timeDeltaInclusion switch
    {
        TimeDeltaInclusion.Disable => "NO",
        TimeDeltaInclusion.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(timeDeltaInclusion), (int)timeDeltaInclusion, typeof(TimeDeltaInclusion))
    });
}