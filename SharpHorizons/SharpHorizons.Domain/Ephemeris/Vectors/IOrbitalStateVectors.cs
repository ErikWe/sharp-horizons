namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Epoch;

using SharpMeasures;

/// <summary>Represents the orbital state vectors (<see cref="Position3"/> and <see cref="Velocity3"/>) of an object at an <see cref="IEpoch"/>.</summary>
public interface IOrbitalStateVectors : IPositionEphemerisEntry, IVelocityEphemerisEntry { }