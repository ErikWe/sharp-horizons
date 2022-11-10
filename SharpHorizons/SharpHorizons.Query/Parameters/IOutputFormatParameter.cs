namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="IOutputFormatParameterIdentifier"/> with an associated <see cref="IOutputFormatArgument"/>.</summary>
public interface IOutputFormatParameter : IQueryParameter<IOutputFormatParameterIdentifier, IOutputFormatArgument> { }