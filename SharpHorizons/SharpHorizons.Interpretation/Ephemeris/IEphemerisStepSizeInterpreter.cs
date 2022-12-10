namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="IStepSize"/>.</summary>
public interface IEphemerisStepSizeInterpreter : IPartInterpreter<IStepSize> { }
