namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Distance"/> component of the <see cref="Position3"/> of an <see cref="IObjectPosition"/>.</summary>
public interface IObjectPositionComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Distance> { }
