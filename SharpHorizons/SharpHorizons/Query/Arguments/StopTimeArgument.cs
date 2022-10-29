namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Calendars;

using System;
using System.Globalization;

/// <inheritdoc cref="IStopTimeArgument"/>
internal sealed record class StopTimeArgument : IStopTimeArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="StopTimeArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public StopTimeArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IStopTimeArgument"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epoch">A <see cref="IStopTimeArgument"/> is composed based on this <see cref="IEpoch"/>, formatted as a <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static IStopTimeArgument Compose(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return new StopTimeArgument($"JD{epoch.ToJulianDay().Day.ToString("F9", CultureInfo.InvariantCulture)}");
    }
}