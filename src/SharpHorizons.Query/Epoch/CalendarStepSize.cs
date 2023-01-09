namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ICalendarStepSize"/>
internal sealed record class CalendarStepSize : ICalendarStepSize
{
    public required int Count { get; init; }
    public required CalendarStepSizeUnit Unit { get; init; }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    private IStepSizeComposer<ICalendarStepSize> Composer { get; }

    /// <inheritdoc cref="CalendarStepSize"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public CalendarStepSize(IStepSizeComposer<ICalendarStepSize> composer)
    {
        Composer = composer;
    }

    /// <inheritdoc cref="CalendarStepSize"/>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public CalendarStepSize(int count, CalendarStepSizeUnit unit, IStepSizeComposer<ICalendarStepSize> composer) : this(composer)
    {
        Count = count;
        Unit = unit;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);
}
