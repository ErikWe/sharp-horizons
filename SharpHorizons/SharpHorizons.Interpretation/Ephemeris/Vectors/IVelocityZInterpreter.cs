namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets the Z-component of the <see cref="Velocity3"/> of an <see cref="IVelocityEphemerisEntry"/>.</summary>
public interface IVelocityZInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Speed> { }
