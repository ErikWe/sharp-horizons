namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="ITimePrecisionParameterIdentifier"/> with an associated <see cref="ITimePrecisionArgument"/>.</summary>
public interface ITimePrecisionParameter : IQueryParameter<ITimePrecisionParameterIdentifier, ITimePrecisionArgument> { }