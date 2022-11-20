namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Epoch;

/// <summary>Describes how <see cref="IEpoch"/> are selected in a query.</summary>
public enum EpochSelectionMode
{
    /// <summary>The <see cref="IEpoch"/> are selected using the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/>.</summary>
    Range,
    /// <summary>The <see cref="IEpoch"/> are selected using a collection of individual <see cref="IEpoch"/>s.</summary>
    Collection
}
