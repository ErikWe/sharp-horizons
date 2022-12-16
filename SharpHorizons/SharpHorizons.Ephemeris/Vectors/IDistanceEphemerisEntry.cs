namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents <see cref="SharpMeasures.Distance"/>-related properties of an object at some <see cref="IEpoch"/>.</summary>
public interface IDistanceEphemerisEntry : IVectorsEphemerisEntry
{
    /// <summary>The <see cref="SharpMeasures.Distance"/> to the object from the origin.</summary>
    public abstract Distance Distance { get; }

    /// <summary>The rate of change of the <see cref="SharpMeasures.Distance"/> to the object - which is the radial <see cref="Speed"/> of the object. A negative <see cref="Speed"/> signifies that the <see cref="Distance"/> is getting smaller.</summary>
    public abstract Speed RadialSpeed { get; }

    /// <summary>The <see cref="Time"/> required for light to travel between the object and the origin (one-way).</summary>
    public abstract Time LightTime { get; }
}
