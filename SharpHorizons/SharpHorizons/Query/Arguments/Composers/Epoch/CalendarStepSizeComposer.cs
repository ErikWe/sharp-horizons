namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="ICalendarStepSize"/>.</summary>
internal sealed class CalendarStepSizeComposer : IStepSizeComposer<ICalendarStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, ICalendarStepSize>.Compose(ICalendarStepSize obj)
    {
        Validate(obj);

        return new QueryArgument($"{obj.Count}{GetUnitText(obj)}");
    }

    /// <summary>Composes a <see cref="string"/> describing the <see cref="CalendarStepSizeUnit"/> of <paramref name="calendarStepSize"/>.</summary>
    /// <param name="calendarStepSize">The composed <see cref="string"/> describes the <see cref="CalendarStepSizeUnit"/> of this <see cref="ICalendarStepSize"/></param>
    /// <exception cref="ArgumentException"/>
    private static string GetUnitText(ICalendarStepSize calendarStepSize)
    {
        try
        {
            return GetUnitText(calendarStepSize.Unit);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ICalendarStepSize>(nameof(calendarStepSize), e);
        }
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="unit"/>.</summary>
    /// <param name="unit">The composed <see cref="string"/> describes this <see cref="CalendarStepSizeUnit"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static string GetUnitText(CalendarStepSizeUnit unit) => unit switch
    {
        CalendarStepSizeUnit.Month => "mo",
        CalendarStepSizeUnit.Year => "y",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(unit)
    };

    /// <summary>Validates the <see cref="ICalendarStepSize"/> <paramref name="stepSize"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="stepSize">This <see cref="ICalendarStepSize"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stepSize"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(ICalendarStepSize stepSize, [CallerArgumentExpression(nameof(stepSize))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(stepSize, argumentExpression);

        try
        {
            Validate(stepSize.Count);
            Validate(stepSize.Unit);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ICalendarStepSize>(argumentExpression, e);
        }
    }

    /// <summary>Validates that the <see cref="int"/> <paramref name="count"/> represents a valid count of a <see cref="ICalendarStepSize"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="count">This <see cref="int"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="count"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(int count, [CallerArgumentExpression(nameof(count))] string? argumentExpression = null)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, count, $"A value greater than 0 should be used to represent the count of a {nameof(ICalendarStepSize)}.");
        }
    }

    /// <summary>Validates that the <see cref="CalendarStepSizeUnit"/> <paramref name="unit"/> represents a valid unit of a <see cref="ICalendarStepSize"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="unit">This <see cref="CalendarStepSizeUnit"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="unit"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void Validate(CalendarStepSizeUnit unit, [CallerArgumentExpression(nameof(unit))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(unit, argumentExpression);

        if (unit is CalendarStepSizeUnit.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(unit, argumentExpression);
        }
    }
}
