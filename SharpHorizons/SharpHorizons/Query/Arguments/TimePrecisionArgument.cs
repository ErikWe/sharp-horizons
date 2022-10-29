namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="ITimePrecisionArgument"/>
internal sealed record class TimePrecisionArgument : ITimePrecisionArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="TimePrecisionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private TimePrecisionArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="ITimePrecisionArgument"/> describing <paramref name="timePrecision"/>.</summary>
    /// <param name="timePrecision">A <see cref="ITimePrecisionArgument"/> is composed based on this <see cref="TimePrecision"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static ITimePrecisionArgument Extract(TimePrecision timePrecision) => new TimePrecisionArgument(timePrecision switch
    {
        TimePrecision.Minute => "M",
        TimePrecision.Second => "S",
        TimePrecision.Millisecond => "F",
        _ => throw new InvalidEnumArgumentException(nameof(timePrecision), (int)timePrecision, typeof(TimePrecision))
    });
}