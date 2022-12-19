namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a <see cref="Distance"/> component of an <see cref="IObjectPositionUncertaintyRTN"/>.</summary>
public interface IObjectPositionUncertaintyRTNComponentInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Distance> { }
