namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;

using SharpMeasures;

/// <summary>Inteprets a component of the <see cref="Displacement3"/> of an <see cref="IObjectPosition"/>.</summary>
public interface ILightTimeInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, Time> { }
