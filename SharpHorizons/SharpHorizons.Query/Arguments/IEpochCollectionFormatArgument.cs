namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Query.Epoch;

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> in the <see cref="IEpochSelection"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
public interface IEpochCollectionFormatArgument : IQueryArgument { }
