namespace SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Represents the orbital state vectors (<see cref="Position3"/> and <see cref="Velocity3"/>) of an object at some <see cref="IEpoch"/>, combined with <see cref="Distance"/>-related properties of the object,
/// and the uncertainty in the <see cref="Position3"/> of the object.</summary>
public interface IExtendedOrbitalStateVectors : IPositionEphemerisEntry, IVelocityEphemerisEntry, IDistanceEphemerisEntry, IPositionalUncertaintyACN, IPositionalUncertaintyPOS, IPositionalUncertaintyRTN, IPositionalUncertaintyXYZ { }
