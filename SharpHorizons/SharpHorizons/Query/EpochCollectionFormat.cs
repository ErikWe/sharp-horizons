namespace SharpHorizons.Query;

using SharpHorizons.Calendars;

/// <summary>Determines the format of the individual <see cref="IEpoch"/> when selected according to <see cref="EpochSelectionMode.Collection"/>.</summary>
public enum EpochCollectionFormat
{
    /// <summary>The <see cref="IEpoch"/> are formatted as <see cref="JulianDay"/>.</summary>
    JulianDays,
    /// <summary>The <see cref="IEpoch"/> are formatted as <see cref="ModifiedJulianDay"/>.</summary>
    ModifiedJulianDays,
    /// <summary>The <see cref="IEpoch"/> are formatted as calendar dates.</summary>
    /// <remarks><see cref="IEpoch"/> prior to the <see cref="GregorianCalendarEpoch"/> { October 15th, 1582 CE 0:00:00 } are formatted as <see cref="JulianCalendarEpoch"/>, and later <see cref="IEpoch"/> are formatted as <see cref="GregorianCalendarEpoch"/>.</remarks>
    CalendarDates
}
