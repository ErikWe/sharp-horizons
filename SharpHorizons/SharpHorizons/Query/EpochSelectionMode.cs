namespace SharpHorizons.Query;

using SharpHorizons.Calendars;

/// <summary>Describes how <see cref="IEpoch"/> are selected in a query.</summary>
public enum EpochSelectionMode
{
    /// <summary>The <see cref="IEpoch"/> are selected using the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/>.</summary>
    Range,
    /// <summary>The <see cref="IEpoch"/> are selected using a collection of individual <see cref="IEpoch"/>s.</summary>
    Collection
}
