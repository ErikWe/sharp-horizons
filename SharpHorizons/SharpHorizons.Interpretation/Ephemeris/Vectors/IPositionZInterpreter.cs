namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets the Z-component of the <see cref="Position3"/> of an <see cref="IPositionEphemerisEntry"/>.</summary>
public interface IPositionZInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Distance> { }
