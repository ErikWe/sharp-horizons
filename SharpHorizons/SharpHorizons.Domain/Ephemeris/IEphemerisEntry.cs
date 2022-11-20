namespace SharpHorizons.Ephemeris;

using SharpHorizons.Epoch;

/// <summary>Represents an entry in an ephemeris of an object, describing properties of the object at an <see cref="IEpoch"/>.</summary>
public interface IEphemerisEntry
{
    /// <summary>The <see cref="IEpoch"/> of the <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch Epoch { get; }
}
