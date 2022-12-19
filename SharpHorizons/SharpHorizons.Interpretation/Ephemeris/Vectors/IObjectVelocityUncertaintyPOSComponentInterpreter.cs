namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Speed"/> component of an <see cref="IObjectVelocityUncertaintyPOS"/>.</summary>
public interface IObjectVelocityUncertaintyPOSComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Speed> { }
