namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="IOriginParameterIdentifier"/> with an associated <see cref="IOriginArgument"/>.</summary>
public interface IOriginParameter : IQueryParameter<IOriginParameterIdentifier, IOriginArgument> { }