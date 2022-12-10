namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as a <see cref="bool"/> describing the inclusion of small-body perturbers.</summary>
public interface ISmallPerturbersInterpreter : IPartInterpreter<bool> { }
