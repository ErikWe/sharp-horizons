namespace SharpHorizons.Query.Epoch;

/// <summary>Specifies the format of the individual <see cref="IEpoch"/> in a query.</summary>
public enum EpochFormat
{
    /// <summary>The <see cref="EpochFormat"/> is unknown.</summary>
    Unknown,
    /// <summary>The <see cref="IEpoch"/> are formatted as Julian days - the fractional number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian calendar }.</summary>
    JulianDays,
    /// <summary>The <see cref="IEpoch"/> are formatted as modified Julian days - the fractional number of days since { 00:00:00 UTC, November 17th, 1858 CE, Gregorian calendar }.</summary>
    /// <remarks>This <see cref="EpochFormat"/> is not supported when using <see cref="EpochSelectionMode.Range"/>.</remarks>
    ModifiedJulianDays,
    /// <summary>The <see cref="IEpoch"/> are formatted as calendar dates.</summary>
    /// <remarks><see cref="CalendarType"/> is used to determine what calendar is used.</remarks>
    CalendarDates
}
