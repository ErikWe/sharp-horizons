namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Speed"/> component of an <see cref="IObjectVelocityUncertaintyACN"/>.</summary>
public interface IObjectVelocityUncertaintyACNComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Speed> { }
