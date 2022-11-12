namespace SharpHorizons;

using SharpHorizons.Calendars;

using SharpMeasures;

/// <inheritdoc cref="IOrbitalStateVectors"/>
internal sealed record class OrbitalStateVectors : IOrbitalStateVectors
{
    public IEpoch Epoch { get; }
    public Position3 Position { get; }
    public Velocity3 Velocity { get; }

    /// <summary>Constructs a new <see cref="OrbitalStateVectors"/> representing an object { <paramref name="position"/>, <paramref name="velocity"/> } at <paramref name="epoch"/>.</summary>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <param name="position"><inheritdoc cref="Position" path="/summary"/></param>
    /// <param name="velocity"><inheritdoc cref="Velocity" path="/summary"/></param>
    public OrbitalStateVectors(IEpoch epoch, Position3 position, Velocity3 velocity)
    {
        Epoch = epoch;

        Position = position;
        Velocity = velocity;
    }
}