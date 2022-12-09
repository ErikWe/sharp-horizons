namespace SharpHorizons.Query.Epoch;

/// <summary>Specifies what calendar is used to express dates.</summary>
public enum CalendarType
{
    /// <summary>The <see cref="CalendarType"/> is unknown.</summary>
    Unknown,
    /// <summary>Dates prior to { 0:00:00 UTC, October 15th, 1582 CE } are expressed in the Julian calendar, and later dates are expressed in the Gregorian calendar.</summary>
    Mixed,
    /// <summary>All dates are expressed in the Gregorian calendar.</summary>
    Gregorian
}
