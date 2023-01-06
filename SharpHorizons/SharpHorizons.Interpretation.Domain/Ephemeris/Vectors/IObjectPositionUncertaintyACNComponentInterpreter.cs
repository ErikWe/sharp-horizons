namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Distance"/> component of an <see cref="IObjectPositionUncertaintyACN"/>.</summary>
public interface IObjectPositionUncertaintyACNComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Distance> { }
