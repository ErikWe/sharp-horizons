namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ICalendarTypeArgument"/> that describe <see cref="CalendarType"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EpochCalendarComposer : IEpochCalendarComposer
{
    ICalendarTypeArgument IArgumentComposer<ICalendarTypeArgument, CalendarType>.Compose(CalendarType obj) => new QueryArgument(obj switch
    {
        CalendarType.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        CalendarType.Mixed => "M",
        CalendarType.Gregorian => "G",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
