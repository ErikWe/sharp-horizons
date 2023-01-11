namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Speed"/> component of the <see cref="Velocity3"/> of an <see cref="IObjectVelocity"/>.</summary>
public interface IObjectVelocityComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Speed> { }
