namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Epoch;

using SharpMeasures;

/// <summary>Represents <see cref="SharpMeasures.Distance"/>-related properties of an object at an <see cref="IEpoch"/>.</summary>
public interface IDistanceEphemerisEntry : IEphemerisEntry
{
    /// <summary>The <see cref="SharpMeasures.Distance"/> to the object.</summary>
    public abstract Distance Distance { get; }

    /// <summary>The rate of change of the <see cref="SharpMeasures.Distance"/> to the object - the radial <see cref="Speed"/> of the object.</summary>
    public abstract Speed DistanceRateOfChange { get; }

    /// <summary>The <see cref="Time"/> required for light to reach the object.</summary>
    public abstract Time LightTime { get; }
}
