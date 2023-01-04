namespace SharpHorizons.Query.Epoch;

/// <summary>Describes the <see cref="IStepSize"/> in a query using some calendar-based unit.</summary>
public interface ICalendarStepSize : IStepSize
{
    /// <summary>Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <see cref="Unit"/>. A step is skipped if the resulting date does not exist.</summary>
    public abstract int Count { get; }

    /// <summary>Determines the calendar-based unit that each step is based on - with <see cref="Count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</summary>
    public abstract CalendarStepSizeUnit Unit { get; }
}
