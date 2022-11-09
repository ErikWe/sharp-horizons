namespace SharpHorizons;

using SharpHorizons.Calendars;

/// <inheritdoc cref="IOsculatingOrbitalElements"/>
internal sealed record class OsculatingOrbitalElements : IOsculatingOrbitalElements
{
    /// <inheritdoc/>
    public IEpoch Epoch { get; }

    /// <summary>Constructs a new <see cref="OsculatingOrbitalElements"/> representing an object at <paramref name="epoch"/>.</summary>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    public OsculatingOrbitalElements(IEpoch epoch)
    {
        Epoch = epoch;
    }
}