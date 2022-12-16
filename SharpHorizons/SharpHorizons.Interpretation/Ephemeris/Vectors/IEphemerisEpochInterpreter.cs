namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;

/// <summary>Inteprets the <see cref="IEpoch"/> of an <see cref="IEphemerisEntry"/>.</summary>
public interface IEphemerisEpochInterpreter : IEphemerisQuantityInterpreter<IVectorsHeader, IEpoch> { }
