namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="IEpoch"/>, describing the <see cref="IEpoch"/> when the query was executed.</summary>
public interface IEphemerisQueryEpochInterpreter : IPartInterpreter<IEpoch> { }
