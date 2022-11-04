namespace SharpHorizons.Vectors;

using SharpHorizons.Calendars;

using SharpMeasures;

/// <summary>Represents the orbital state vectors, the <see cref="Position3"/> and <see cref="Velocity3"/>, of an object at an <see cref="IEpoch"/>.</summary>
public sealed record class OrbitalStateVectors
{
    /// <summary>The epoch of the orbital state vectors.</summary>
    public IEpoch Epoch { get; }

    /// <summary>The <see cref="Position3"/> of the object.</summary>
    public Position3 Position { get; }

    /// <summary>The <see cref="Velocity3"/> of the object.</summary>
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