namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOrbitalStateVectors"/>
internal sealed record class OrbitalStateVectors : IOrbitalStateVectors
{
    public required IEpoch Epoch { get; init; }

    public required Position3 Position { get; init; }
    public required Velocity3 Velocity { get; init; }

    /// <inheritdoc cref="OrbitalStateVectors"/>
    public OrbitalStateVectors() { }

    /// <inheritdoc cref="OrbitalStateVectors"/>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="position"><inheritdoc cref="Position" path="/summary"/></param>
    /// <param name="velocity"><inheritdoc cref="Velocity" path="/summary"/></param>
    [SetsRequiredMembers]
    public OrbitalStateVectors(IEpoch epoch, Position3 position, Velocity3 velocity)
    {
        Epoch = epoch;
        Position = position;
        Velocity = velocity;
    }
}
