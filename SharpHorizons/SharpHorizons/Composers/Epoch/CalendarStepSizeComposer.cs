namespace SharpHorizons.Composers.Epoch;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;

using System;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="ICalendarStepSize"/>.</summary>
internal sealed class CalendarStepSizeComposer : IStepSizeComposer<ICalendarStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, ICalendarStepSize>.Compose(ICalendarStepSize obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"{obj.Count}{GetUnitText(obj.Unit)}");
    }

    /// <summary>Composes a <see cref="string"/> describing the <paramref name="unit"/>.</summary>
    /// <param name="unit">The composed <see cref="string"/> describes this <see cref="CalendarStepSizeUnit"/></param>
    /// <exception cref="NotSupportedException"/>
    private static string GetUnitText(CalendarStepSizeUnit unit) => unit switch
    {
        CalendarStepSizeUnit.Month => "mo",
        CalendarStepSizeUnit.Year => "y",
        _ => throw new NotSupportedException($"{unit} was not of a supported {typeof(CalendarStepSizeUnit).FullName}.")
    };
}
