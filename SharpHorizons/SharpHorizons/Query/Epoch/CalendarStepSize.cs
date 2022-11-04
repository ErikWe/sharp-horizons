namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Composers.Arguments;

using System;
using System.ComponentModel;

/// <inheritdoc cref="ICalendarStepSize"/>
internal sealed record class CalendarStepSize : ICalendarStepSize
{
    /// <inheritdoc/>
    public int Count { get; }

    /// <inheritdoc/>
    public CalendarStepSizeUnit Unit { get; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    private IStepSizeComposer<ICalendarStepSize> Composer { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>.</summary>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public CalendarStepSize(int count, CalendarStepSizeUnit unit, IStepSizeComposer<ICalendarStepSize> composer)
    {
        if (Enum.IsDefined(typeof(CalendarStepSize), unit) is false)
        {
            throw new InvalidEnumArgumentException(nameof(unit), (int)unit, typeof(CalendarStepSizeUnit));
        }
        
        Count = count;
        Unit = unit;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
