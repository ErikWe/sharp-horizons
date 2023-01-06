namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="bool"/> describing the inclusion of small-body perturbers.</summary>
public interface ISmallPerturbersInterpreter : IInterpreter<bool> { }
