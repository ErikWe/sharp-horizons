namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="IEpoch"/>, describing the <see cref="IEpoch"/> when the query was executed.</summary>
public interface IEphemerisQueryEpochInterpreter : IInterpreter<IEpoch> { }
