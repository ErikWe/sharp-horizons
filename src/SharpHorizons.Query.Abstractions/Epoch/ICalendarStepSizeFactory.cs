namespace SharpHorizons.Query.Epoch;

using System;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="ICalendarStepSize"/>, describing the <see cref="IStepSize"/> in a query using some calendar-based unit.</summary>
/// <remarks>To construct <see cref="IStepSize"/> using a non-variable calendar-related unit, such as days or weeks, use <see cref="IFixedStepSizeFactory"/>.</remarks>
public interface ICalendarStepSizeFactory
{
    /// <summary>Describes the <see cref="IStepSize"/> in a query such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>.</summary>
    /// <param name="count"><inheritdoc cref="ICalendarStepSize.Count" path="/summary"/></param>
    /// <param name="unit"><inheritdoc cref="ICalendarStepSize.Unit" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>0
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract ICalendarStepSize Create(int count, CalendarStepSizeUnit unit);
}
