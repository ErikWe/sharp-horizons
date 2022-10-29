namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Calendars;

using System;
using System.Globalization;

/// <inheritdoc cref="IStartTimeArgument"/>
internal sealed record class StartTimeArgument : IStartTimeArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="StartTimeArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public StartTimeArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IStartTimeArgument"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epoch">A <see cref="IStartTimeArgument"/> is composed based on this <see cref="IEpoch"/>, formatted as a <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public static IStartTimeArgument Compose(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return new StartTimeArgument($"JD{epoch.ToJulianDay().Day.ToString("F9", CultureInfo.InvariantCulture)}");
    }
}