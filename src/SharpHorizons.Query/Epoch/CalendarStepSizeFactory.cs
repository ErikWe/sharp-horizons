namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using System;

/// <inheritdoc cref="ICalendarStepSizeFactory"/>
internal sealed class CalendarStepSizeFactory : ICalendarStepSizeFactory
{
    /// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="ICalendarStepSize"/>.</summary>
    private IStepSizeComposer<ICalendarStepSize> Composer { get; }

    /// <inheritdoc cref="CalendarStepSizeFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public CalendarStepSizeFactory(IStepSizeComposer<ICalendarStepSize>? composer = null)
    {
        Composer = composer ?? new CalendarStepSizeComposer();
    }

    ICalendarStepSize ICalendarStepSizeFactory.Create(int count, CalendarStepSizeUnit unit)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), count, $"A value greater than 0 should be used to represent the count of a {nameof(ICalendarStepSize)}.");
        }

        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(unit);

        if (unit is CalendarStepSizeUnit.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(unit);
        }

        return new CalendarStepSize(count, unit, Composer);
    }
}
