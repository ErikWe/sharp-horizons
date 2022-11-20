namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="ICalendarStepSize"/>
internal sealed record class CalendarStepSize : ICalendarStepSize
{
    public required int Count { get; init; }
    public required CalendarStepSizeUnit Unit
    {
        get => _Unit;
        init
        {
            ValidateCalendarStepSizeUnit(value);

            _Unit = value;
        }
    }

    /// <summary>Used to compose a <see cref="IStepSizeArgument"/> describing <see langword="this"/>.</summary>
    public required IStepSizeComposer<ICalendarStepSize> Composer { private get; init; }

    /// <inheritdoc cref="Unit"/>
    private CalendarStepSizeUnit _Unit { get; init; }

    /// <inheritdoc cref="CalendarStepSize"/>
    public CalendarStepSize() { }

    /// <inheritdoc cref="CalendarStepSize"/>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    [SetsRequiredMembers]
    public CalendarStepSize(int count, CalendarStepSizeUnit unit, IStepSizeComposer<ICalendarStepSize> composer)
    {
        ValidateCalendarStepSizeUnit(unit);
        
        Count = count;
        Unit = unit;

        Composer = composer;
    }

    IStepSizeArgument IStepSize.ComposeArgument() => Composer.Compose(this);

    /// <summary>Throws an <see cref="InvalidEnumArgumentException"/> if <paramref name="unit"/> does not represent a valid <see cref="CalendarStepSizeUnit"/>.</summary>
    /// <param name="unit">A <see cref="InvalidEnumArgumentException"/> is thrown if this <see cref="CalendarStepSizeUnit"/> is invalid.</param>
    /// <param name="parameterName">The name of the parameter with which <paramref name="unit"/> corresponds.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateCalendarStepSizeUnit(CalendarStepSizeUnit unit, [CallerArgumentExpression("unit")] string? parameterName = null)
    {
        if (Enum.IsDefined(typeof(CalendarStepSize), unit) is false)
        {
            throw new InvalidEnumArgumentException(parameterName, (int)unit, typeof(CalendarStepSizeUnit));
        }
    }
}
