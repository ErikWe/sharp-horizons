namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets the X-component of the <see cref="Velocity3"/> of an <see cref="IVelocityEphemerisEntry"/>.</summary>
public interface IVelocityXInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Speed> { }
