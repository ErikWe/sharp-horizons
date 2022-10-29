namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;

using System;
using System.ComponentModel;

/// <summary>Describes the <see cref="IStepSize"/> in a query in a non-uniform fashion, such that each step represents a difference of some calendar-based unit.</summary>
internal readonly record struct CalendarStepSize : IStepSize
{
    /// <summary>Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <see cref="Unit"/>. A step might be discarded if the resulting date does not exist.</summary>
    private int Count { get; }

    /// <summary>Determines the calendar-based unit that each step is based on - with <see cref="Count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</summary>
    private CalendarStepSizeUnit Unit { get; }

    /// <summary>Describes the <see cref="IStepSize"/> in a query in a non-uniform fashion, such that each step represents a difference of a fixed number of months or years.</summary>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public CalendarStepSize(int count, CalendarStepSizeUnit unit)
    {
        Count = count;
        Unit = unit;

        if (Enum.IsDefined(typeof(CalendarStepSize), unit) is false)
        {
            throw new InvalidEnumArgumentException(nameof(unit), (int)unit, typeof(CalendarStepSizeUnit));
        }
    }

    IStepSizeArgument IStepSize.ComposeArgument()
    {
        var unitText = Unit switch
        {
            CalendarStepSizeUnit.Month => "mo",
            CalendarStepSizeUnit.Year => "y",
            _ => throw new NotSupportedException($"{Unit} was not of a supported {typeof(CalendarStepSizeUnit).FullName}")
        };

        return new StepSizeArgument($"{Count}{unitText}");
    }
}
