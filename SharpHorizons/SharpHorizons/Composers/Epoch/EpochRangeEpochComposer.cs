namespace SharpHorizons.Composers.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IStartEpochArgument"/> and <see cref="IStopEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
internal sealed class EpochRangeEpochComposer : IStartEpochComposer<IEpoch>, IStopEpochComposer<IEpoch>
{
    IStartEpochArgument IArgumentComposer<IStartEpochArgument, IEpoch>.Compose(IEpoch obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument(Compose(obj));
    }

    IStopEpochArgument IArgumentComposer<IStopEpochArgument, IEpoch>.Compose(IEpoch obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument(Compose(obj));
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The composed <see cref="string"/> describes this <see cref="IEpoch"/>.</param>
    private static string Compose(IEpoch epoch) => $"JD{epoch.ToJulianDay().Day.ToString("F9", CultureInfo.InvariantCulture)}";
}
