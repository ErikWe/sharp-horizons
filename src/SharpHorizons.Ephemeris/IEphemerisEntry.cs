namespace SharpHorizons.Ephemeris;

/// <summary>Represents an entry in an <see cref="IEphemeris{TEntry}"/> of an object, describing properties of the object at some <see cref="IEpoch"/>.</summary>
public interface IEphemerisEntry
{
    /// <summary>The <see cref="IEpoch"/> of the <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch Epoch { get; }
}
