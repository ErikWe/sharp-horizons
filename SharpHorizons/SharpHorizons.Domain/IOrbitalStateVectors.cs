namespace SharpHorizons;

using SharpHorizons.Calendars;

using SharpMeasures;

/// <summary>Represents the orbital state vectors, the <see cref="Position3"/> and <see cref="Velocity3"/>, of an object at an <see cref="IEpoch"/>.</summary>
public interface IOrbitalStateVectors
{
    /// <summary>The <see cref="IEpoch"/> of the <see cref="IOrbitalStateVectors"/>.</summary>
    public abstract IEpoch Epoch { get; }

    /// <summary>The <see cref="Position3"/> of the object.</summary>
    public abstract Position3 Position { get; }

    /// <summary>The <see cref="Velocity3"/> of the object.</summary>
    public abstract Velocity3 Velocity { get; }
}