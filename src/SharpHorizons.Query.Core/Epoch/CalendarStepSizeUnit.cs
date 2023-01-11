namespace SharpHorizons.Query.Epoch;

/// <summary>Describes the unit used when defining a calendar-based, non-uniform <see cref="IStepSize"/>.</summary>
public enum CalendarStepSizeUnit
{
    /// <summary>The <see cref="CalendarStepSizeUnit"/> is unknown.</summary>
    Unknown,
    /// <summary>Each step represents the same day-of-the-month and time - but of different months.</summary>
    Month,
    /// <summary>Each step represents the same month, day-of-the-month, and time - but of different years.</summary>
    Year
}
