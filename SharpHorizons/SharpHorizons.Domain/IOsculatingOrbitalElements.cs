namespace SharpHorizons;

using SharpHorizons.Calendars;

/// <summary>Represents the osculating orbital elements of an object at an <see cref="IEpoch"/>.</summary>
public interface IOsculatingOrbitalElements
{
    /// <summary>The epoch of the <see cref="IOsculatingOrbitalElements"/>.</summary>
    public abstract IEpoch Epoch { get; }
}