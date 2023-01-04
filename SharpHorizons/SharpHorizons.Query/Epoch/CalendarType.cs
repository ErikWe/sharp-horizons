namespace SharpHorizons.Query.Epoch;

/// <summary>Specifies in what calendar <see cref="IEpoch"/> are expressed in a query.</summary>
public enum CalendarType
{
    /// <summary>The <see cref="CalendarType"/> is unknown.</summary>
    Unknown,
    /// <summary><see cref="IEpoch"/> prior to { 0:00:00 UTC, October 15th, 1582 CE } are expressed in the Julian calendar, and later <see cref="IEpoch"/> are expressed in the Gregorian calendar.</summary>
    Mixed,
    /// <summary>All <see cref="IEpoch"/> are expressed in the Gregorian calendar.</summary>
    Gregorian
}
