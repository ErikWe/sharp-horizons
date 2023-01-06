namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Distance"/> component of the <see cref="Displacement3"/> of an <see cref="IObjectPositionUncertaintyXYZ"/>.</summary>
public interface IObjectPositionUncertaintyXYZComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Distance> { }
