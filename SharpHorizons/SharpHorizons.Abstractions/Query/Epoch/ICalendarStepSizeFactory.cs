namespace SharpHorizons.Query.Epoch;

using System;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="ICalendarStepSize"/>, describing the <see cref="IStepSize"/> in a query using some calendar-based unit.</summary>
/// <remarks>To construct <see cref="IStepSize"/> using a non-variable calendar-related unit, such as days or weeks, use <see cref="IFixedStepSizeFactory"/>.</remarks>
public interface ICalendarStepSizeFactory
{
    /// <summary>Describes the <see cref="IStepSize"/> in a query such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>.</summary>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract ICalendarStepSize Create(int count, CalendarStepSizeUnit unit);
}
