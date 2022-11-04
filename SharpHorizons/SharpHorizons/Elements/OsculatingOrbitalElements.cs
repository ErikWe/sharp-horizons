namespace SharpHorizons.Elements;

using SharpHorizons.Calendars;

/// <summary>Represents the osculating orbital elements of an object at an <see cref="IEpoch"/>.</summary>
public sealed record class OsculatingOrbitalElements
{
    /// <summary>The epoch of the <see cref="OsculatingOrbitalElements"/>.</summary>
    public IEpoch Epoch { get; }

    /// <summary>Constructs a new <see cref="OsculatingOrbitalElements"/> representing an object at <paramref name="epoch"/>.</summary>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    public OsculatingOrbitalElements(IEpoch epoch)
    {
        Epoch = epoch;
    }
}